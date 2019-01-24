using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class UserFriendsViewModel : ViewModelBase
    {
        #region Private fields

        private RelayCommand searchCommand;

        #endregion

        public static UserFriendsViewModel Instance;

        public UserFriendsViewModel()
        {
            if (Instance == null)
                Instance = this;
        }

        #region Bindings

        public ObservableCollection<FriendItemPageViewModel> AuxSearchUsers = new ObservableCollection<FriendItemPageViewModel>();

        private ObservableCollection<FriendItemPageViewModel> friends;
        public ObservableCollection<FriendItemPageViewModel> FriendsList
        {
            get
            {
                if (friends == null)
                {
                    friends = new ObservableCollection<FriendItemPageViewModel>();
                    foreach(var friend in UserRightSideViewModel.Instance.FriendsList)
                    {
                        friends.Add(new FriendItemPageViewModel
                        {
                            UserName = friend.userName,
                            FirstName = friend.firstName,
                            LastName = friend.lastName,
                            CoverImage = friend.CoverImage,
                            IsFriend = true,
                            LastLogin = friend.LastLogin
                        });
                    }
                }
                return friends;
            }
            set
            {
                friends = value;
                OnPropertyChanged("FriendsList");
            }
        }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private ObservableCollection<FriendItemPageViewModel> searchFriends;
        public ObservableCollection<FriendItemPageViewModel> SearchFriends
        {
            get
            {
                if (searchFriends == null)
                {
                    searchFriends = new ObservableCollection<FriendItemPageViewModel>();

                    try
                    {
                        using (var context = new DataAccess.SountyDB())
                        {
                            var users = (from user in context.UserInfoes
                                         select new
                                         {
                                             user.firstName,
                                             user.lastName,
                                             user.Image.imagePath,
                                             user.UserSounty.userName,
                                             user.lastLogin
                                         });

                            bool isFriendValue;

                            foreach(var user in users)
                            {
                                if (user.userName == UserRightSideViewModel.Instance.userSounty.userName)
                                    continue;

                                if (friends.Any(p => p.LastName == user.lastName && p.FirstName == user.firstName))
                                    isFriendValue = true;
                                else
                                    isFriendValue = false;

                                DateTime lastLoginForFriend = user.lastLogin ?? DateTime.Now;
                                var insertValueLastLogin = lastLoginForFriend != DateTime.Now ? (DateTime.Now - lastLoginForFriend).Minutes.ToString() + " minutes ago" : String.Empty;


                                searchFriends.Add(new FriendItemPageViewModel
                                {
                                    UserName = user.userName,
                                    FirstName = user.firstName,
                                    LastName = user.lastName,
                                    CoverImage = String.IsNullOrEmpty(user.imagePath) ? @"/Resources/Images/NoProfileImage.png" : user.imagePath,
                                    IsFriend = isFriendValue,
                                    LastLogin = insertValueLastLogin
                                });
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        return null;
                    }
                }

                return searchFriends;
            }
            set
            {
                searchFriends = value;
                OnPropertyChanged("SearchFriends");
            }
        }

        #endregion

        #region Commands

        private bool errorSearchingVisibility = false;

        public bool ErrorSearchingVisibility
        {
            get => errorSearchingVisibility;
            set
            {
                errorSearchingVisibility = value;
                OnPropertyChanged("ErrorSearchingVisibility");
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(t => this.Search());

                return searchCommand;
            }
        }

        void Search()
        {
            if (String.IsNullOrEmpty(SearchText) || SearchText.Count() < 1)
            {
                if (AuxSearchUsers != SearchFriends)
                    SearchFriends = AuxSearchUsers;
                return;
            }
            else
            {
                var itemsFound = SearchFriends.Where(p => p.FirstName.Contains(SearchText) ||
                                           p.LastName.Contains(SearchText) ||
                                           p.UserName.Contains(SearchText));

                if (itemsFound.Count() != 0)
                {
                    AuxSearchUsers = SearchFriends;
                    SearchFriends = new ObservableCollection<FriendItemPageViewModel>();
                }
                else
                {
                    ErrorSearchingVisibility = true;
                    return;
                }

                foreach(var item in itemsFound)
                {
                    SearchFriends.Add(item);
                }
                ErrorSearchingVisibility = false;
            }
            
        }
    


        #endregion

    }
}
