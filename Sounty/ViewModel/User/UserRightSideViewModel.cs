using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Sounty.Model;

namespace Sounty.ViewModel
{
    public class UserRightSideViewModel : ViewModelBase
    {
        const string defaultCoverImage = @"/Resources/Images/NoProfileImage.png";
        const string defaultFacebookUrl = @"https://www.facebook.com";
        const string defaultInstagramUrl = @"https://www.instagram.com";
        const string defaultYoutubeUrl = @"https://www.youtube.com";

        public string FacebookURL
        {
            get => userInfo.facebookPage;
            set
            {
                userInfo.facebookPage = value;
            }
        }
        public string InstagramURL
        {
            get => userInfo.instagramPage;
            set
            {
                userInfo.instagramPage = value;
            }
        }
        public string YoutubeURL
        {
            get => userInfo.youtubePage;
            set
            {
                userInfo.youtubePage = value;
            }
        }
        
        private string  userProfileImagePath;
        private bool    notPremiumVisibility;
        private bool    premiumVisibility;
        public DateTime expiresDate;

        public DataAccess.UserInfo     userInfo;
        public DataAccess.UserSounty   userSounty;

        RelayCommand facebookCommand;
        RelayCommand instagramCommand;
        RelayCommand youtubeCommand;

        RelayCommand editProfileCommand;

        private ObservableCollection<FriendListItem> friends;
        public ObservableCollection<FriendListItem> FriendsList
        {
            get
            {
                if (friends == null)
                    friends = new ObservableCollection<FriendListItem>();
                return friends;
            }
            set
            {
                friends = value;
                OnPropertyChanged("FriendsList");
            }
        }

        #region Singleton

        private static UserRightSideViewModel instance;
        public static  UserRightSideViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRightSideViewModel();

                return instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        public static UserRightSideViewModel FillViewModel(int userId)
        {
            Instance.GetUserInfos(userId);

            Instance.FriendsList = new ObservableCollection<FriendListItem>();
            Instance.FillFriendsList(userId);

            return instance;
        }

        UserRightSideViewModel()
        {
        }
        
        #endregion

        #region Private methods

        private void FillFriendsList(int userId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var friends = (from friend in context.Friends
                                   where friend.userId == userId
                                   select friend.friendId);

                    foreach(var friendId in friends)
                    {
                        var friendInfo = (from user in context.UserInfoes
                                          where user.userInfoId == friendId
                                          select new
                                          {
                                              user.firstName,
                                              user.lastName,
                                              user.lastLogin,
                                              user.activeStatus,
                                              user.profileImage,
                                              user.UserSounty.userName
                                          }).Single();

                        var item = new FriendListItem();
                        item.Name = friendInfo.firstName + " " + friendInfo.lastName;
                        item.CoverImage = ImagesModel.Instance.GetImagePath(friendInfo.profileImage ?? 0);
                        item.online = friendInfo.activeStatus ?? false;
                        item.firstName = friendInfo.firstName;
                        item.lastName = friendInfo.lastName;
                        item.userName = friendInfo.userName;
                       
                        // last login
                        DateTime lastLoginForFriend = friendInfo.lastLogin ?? DateTime.Now;
                        item.LastLogin = lastLoginForFriend != DateTime.Now ? (DateTime.Now - lastLoginForFriend).Minutes.ToString() + " minutes ago" : String.Empty;

                        FriendsList.Add(item);
                    }
                };
            }
            catch(Exception)
            {
                return;
            }
        }

        private void GetUserInfos(int userId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var resultsUserInfo = (from item in context.UserInfoes
                                   where item.userInfoId == userId
                                   select item).First();

                    userInfo = resultsUserInfo;

                    var resultsUserSounty = (from item in context.UserSounties
                                             where item.userId == userId
                                   select item).First();

                    userSounty = resultsUserSounty;

                    if (userInfo.profileImage != null)
                    {
                        UserProfileImagePath = (from imagePath in context.Images
                                                where imagePath.imageId == userInfo.profileImage
                                                select imagePath.imagePath).FirstOrDefault();
                    }
                    else
                    {
                        UserProfileImagePath = defaultCoverImage;
                    }

                    if (userInfo.instagramPage == null)
                    {
                        InstagramURL = defaultInstagramUrl;
                    }
                    if (userInfo.facebookPage == null)
                    {
                        FacebookURL = defaultFacebookUrl;
                    }
                    if (userInfo.youtubePage == null)
                    {
                        YoutubeURL = defaultYoutubeUrl;
                    }

                    if (userInfo.subscriptionId != null)
                    {
                        var subscription = (from subscriptionItem in context.Subscriptions
                                            where subscriptionItem.subscriptionId == userInfo.subscriptionId
                                            select subscriptionItem).Single();

                        if (subscription.endDate < DateTime.Today)
                        {
                            NotPremiumVisibility = true;
                            userInfo.subscriptionId = null;
                            context.Subscriptions.Remove(subscription);
                        }
                        else
                        {
                            expiresDate = subscription.endDate ?? DateTime.MinValue;
                            PremiumVisibility = true;
                        }
                    }
                    else
                        NotPremiumVisibility = true;
                    
                    context.SaveChanges();
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        #endregion

        #region Bindings

        public bool NotPremiumVisibility
        {
            get => notPremiumVisibility;
            set
            {
                notPremiumVisibility = value;
                OnPropertyChanged("NotPremiumVisibility");
            }
        }

        public bool PremiumVisibility
        {
            get => premiumVisibility;
            set
            {
                premiumVisibility = value;
                OnPropertyChanged("PremiumVisibility");
            }
        }

        public string UserProfileImagePath
        {
            get => userProfileImagePath;
            set
            {
                userProfileImagePath = value;
                OnPropertyChanged("UserProfileImagePath");
            }
        }

        public string LastName
        {
            get => userInfo.lastName;
            set
            {
                userInfo.lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string FirstName
        {
            get => userInfo.firstName;
            set
            {
                userInfo.firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public bool HasSubscription
        {
            get
            {
                return (userInfo.subscriptionId != 0) ? true : false;
            }
        }

        #endregion

        #region Commands

        public ICommand FacebookCommand
        {
            get
            {
                if(facebookCommand == null)
                    facebookCommand = new RelayCommand(t => System.Diagnostics.Process.Start(FacebookURL));

                return facebookCommand;
            }
        }

        public ICommand InstagramCommand
        {
            get
            {
                if (instagramCommand == null)
                    instagramCommand = new RelayCommand(t => System.Diagnostics.Process.Start(InstagramURL));

                return instagramCommand;
            }
        }

        public ICommand YoutubeCommand
        {
            get
            {
                if (youtubeCommand == null)
                    youtubeCommand = new RelayCommand(t => System.Diagnostics.Process.Start(YoutubeURL));

                return youtubeCommand;
            }
        }

        public ICommand EditProfileCommand
        {
            get
            {
                if (editProfileCommand == null)
                    editProfileCommand = new RelayCommand(t => this.EditProfile());

                return editProfileCommand;
            }
        }

        void EditProfile()
        {
            MainWindowViewModel.Instance.Workspace = EditUserViewModel.CreateWithParameters(userInfo, userSounty);
        }

        #endregion

    }
}
