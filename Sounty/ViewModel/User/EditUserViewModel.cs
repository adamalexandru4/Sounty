using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    class EditUserViewModel : ViewModelBase
    {
        const string defaultCoverImage = @"/Resources/Images/NoProfileImage.png";

        private RelayCommand firstPageCommand;
        private RelayCommand editInfoCommand;
        private RelayCommand changePasswordCommand;
        private RelayCommand subscriptionCommand;
        private RelayCommand friendsCommand;

        private ViewModelBase userPage;

        private string helloName;

        #region Constructor

        private static EditUserViewModel instance;
        public static EditUserViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new EditUserViewModel();

                return instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        public static EditUserViewModel CreateWithParameters(DataAccess.UserInfo userInfo, DataAccess.UserSounty userSounty)
        {
            Instance.HelloName = userInfo.firstName;
            Instance.UserPage = new EditUserFirstPageViewModel();

            return instance;
        }

        public static EditUserViewModel CreateWithParametersFriends(DataAccess.UserInfo userInfo, DataAccess.UserSounty userSounty)
        {
            Instance.HelloName = userInfo.firstName;
            Instance.UserPage = new UserFriendsViewModel();

            return instance;
        }

        EditUserViewModel()
        {

        }
        
        #endregion

        #region Bindings

        public string HelloName
        {
            get => helloName;
            set
            {
                helloName = value;
                OnPropertyChanged("HelloName");
            }
        }

        private string coverImagePath = UserRightSideViewModel.Instance.UserProfileImagePath;

        public string CoverImagePath
        {
            get => coverImagePath;
            set
            {
                coverImagePath = value;
                OnPropertyChanged("CoverImagePath");
            }
        }

        public ViewModelBase UserPage
        {
            set
            {
                userPage = value;
                OnPropertyChanged("UserPage");
            }
            get => userPage;
        }

        #endregion

        #region Commands

        public ICommand FirstPageCommand
        {
            get
            {
                if (firstPageCommand == null)
                    firstPageCommand = new RelayCommand(t => GoToFirstPage());

                return firstPageCommand;
            }
        }

        void GoToFirstPage()
        {
            EditUserViewModel.Instance.UserPage = new EditUserFirstPageViewModel();
        }

        public ICommand EditProfileCommand
        {
            get
            {
                if (editInfoCommand == null)
                    editInfoCommand = new RelayCommand(t => EditInfo());

                return editInfoCommand;
            }
        }

        public static void EditInfo()
        {
            EditUserViewModel.Instance.UserPage = new EditProfileViewModel();
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (changePasswordCommand == null)
                    changePasswordCommand = new RelayCommand(t => this.ChangePassword());

                return changePasswordCommand;
            }
        }

        void ChangePassword()
        {
            EditUserViewModel.Instance.UserPage = ChangePasswordViewModel.Instance;
        }

        public ICommand SubscriptionCommand
        {
            get
            {
                if (subscriptionCommand == null)
                    subscriptionCommand = new RelayCommand(t => this.Subscription());

                return subscriptionCommand;
            }
        }
        
        void Subscription()
        {
            EditUserViewModel.Instance.UserPage = new SubscriptionViewModel();
        }

        public ICommand FriendsCommand
        {
            get
            {
                if (friendsCommand == null)
                    friendsCommand = new RelayCommand(t => this.Friends());

                return friendsCommand;
            }
        }

        void Friends()
        {
            Instance.UserPage = new UserFriendsViewModel();
        }
        #endregion

    }
}
