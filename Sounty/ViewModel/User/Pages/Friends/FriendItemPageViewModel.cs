using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class FriendItemPageViewModel : ViewModelBase
    {

        private string firstName;
        private string lastName;
        private string userName;
        private string coverImage;
        private bool isFriend;
        public string LastLogin;
        
        public bool IsFriend
        {
            get => isFriend;
            set
            {
                if(value == true)
                {
                    AddVisibility = false;
                    RemoveVisibility = true;
                }
                else
                {
                    AddVisibility = true;
                    RemoveVisibility = false;
                }
                isFriend = value;
            }
        }

        private RelayCommand addCommand;
        private RelayCommand removeCommand;

        #region Constructor

        public FriendItemPageViewModel()
        {

        }

        public FriendItemPageViewModel(FriendListItem item, bool isFriend)
        {
            this.FirstName  = item.firstName;
            this.LastName   = item.lastName;
            this.UserName   = item.userName;

            this.isFriend   = isFriend;
            if(isFriend == true)
            {
                AddVisibility = false;
                RemoveVisibility = true;
            }
            else
            {
                AddVisibility = true;
                RemoveVisibility = false;
            }

            this.CoverImage = item.CoverImage;
        }

        #endregion

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string CoverImage
        {
            get
            {
                if (coverImage == string.Empty)
                    return @"/Resources/Images/NoProfileImage.png";
                return coverImage;
            }
            set
            {
                coverImage = value;
                OnPropertyChanged("CoverImage");
            }
        }

        private bool addVisibility;

        public bool AddVisibility
        {
            get => addVisibility;
            set
            {
                addVisibility = value;
                OnPropertyChanged("AddVisibility");
            }
        }

        private bool removeVisibility;

        public bool RemoveVisibility
        {
            get => removeVisibility;
            set
            {
                removeVisibility = value;
                OnPropertyChanged("RemoveVisibility");
            }
        }

        #region Commands

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(t => Add());

                return addCommand;
            }
        }

        void Add()
        {
            UserFriendsViewModel.Instance.FriendsList.Add(new FriendItemPageViewModel
            {
                firstName = this.firstName,
                lastName = this.lastName,
                userName = this.userName,
                coverImage = this.coverImage,
                IsFriend = true
            });

            foreach (var friend in UserFriendsViewModel.Instance.SearchFriends.Where(p => p.userName == this.userName))
            {
                friend.AddVisibility = false;
                friend.RemoveVisibility = true;
                friend.IsFriend = true;
                break;
            }

            UserRightSideViewModel.Instance.FriendsList.Add(new FriendListItem
            {
                Name = firstName + " " + lastName,
                CoverImage = this.CoverImage,
                online = false,
                userName = this.userName,
                firstName = this.firstName,
                lastName = this.lastName,
                LastLogin = this.LastLogin
            });

            using (var context = new DataAccess.SountyDB())
            {
                var friendID = (from user in context.UserInfoes
                                where user.firstName == this.firstName && user.lastName == this.lastName
                                select user.userInfoId).Single();

                var newFriend = new DataAccess.Friend
                {
                    userId = UserRightSideViewModel.Instance.userInfo.userInfoId,
                    friendId = friendID
                };

                context.Friends.Add(newFriend);
                context.SaveChanges();
            }

        }

        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                    removeCommand = new RelayCommand(t => Remove());

                return removeCommand;
            }
        }

        void Remove()
        {
            var deletedFriend = UserFriendsViewModel.Instance.FriendsList.Single(p => p.userName == this.userName);
            UserFriendsViewModel.Instance.FriendsList.Remove(deletedFriend);

            foreach (var friend in UserFriendsViewModel.Instance.SearchFriends.Where(p => p.userName == this.userName))
            {
                friend.AddVisibility = true;
                friend.RemoveVisibility = false;
                friend.IsFriend = false;
                break;
            }

            var deleteRight = UserRightSideViewModel.Instance.FriendsList.Single(p => p.userName == this.UserName);
            UserRightSideViewModel.Instance.FriendsList.Remove(deleteRight);

            using (var context = new DataAccess.SountyDB())
            {
                var friendID = (from user in context.UserInfoes
                                where user.firstName == this.firstName && user.lastName == this.lastName
                                select user.userInfoId).Single();

                var userWithFriend = (from item in context.Friends
                                      where item.userId == UserRightSideViewModel.Instance.userInfo.userInfoId &&
                                            item.friendId == friendID
                                      select item).Single();
                context.Friends.Remove(userWithFriend);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
