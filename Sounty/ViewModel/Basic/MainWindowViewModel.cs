using Sounty.Model;

namespace Sounty.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        private static MainWindowViewModel instance;
        public  static MainWindowViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindowViewModel();
                }
                return instance;
            }
        }

        private MenuViewModel menu;
        public  MenuViewModel Menu
        {
            get
            {
                return menu;
            }
            private set
            {
                menu = value;
                OnPropertyChanged("Menu");
            }
        }

        private ViewModelBase workspace;
        public  ViewModelBase Workspace
        {
            get
            {
                return workspace;
            }
            set
            {
                workspace = value;
                OnPropertyChanged("Workspace");
            }
        }

        private PlayerViewModel player;
        public  PlayerViewModel Player
        {
            get
            {
                return player;
            }
            private set
            {
                player = value;
                OnPropertyChanged("Player");
            }
        }

        public static void FillUserInfo(int userId)
        {
            Instance.UserInfo = UserRightSideViewModel.FillViewModel(userId);
            Instance.imageModel = new ImagesModel();
        }


        public ViewModelBase UserInfo
        {
            get
            {
                return userInfo;
            }
            set
            {
                userInfo = value;
                OnPropertyChanged("UserInfo");
            }
        }
        #endregion

        #region Constructors

        ImagesModel imageModel;
        ViewModelBase userInfo;

        private MainWindowViewModel()
        {
            Menu        = MenuViewModel.Instance;
            Player      = PlayerViewModel.Instance;
            Workspace   = new HomeViewModel();

        }

        public static void Reset()
        {
            Instance.Workspace = new HomeViewModel();
        }
        #endregion
    }
}
