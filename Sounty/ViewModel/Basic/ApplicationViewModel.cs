using Sounty.Resources;

namespace Sounty.ViewModel
{
    class ApplicationViewModel : ViewModelBase
    {
        #region Fields

        public IDialogService dialogService;

        #endregion

        #region Properties

        private static ApplicationViewModel instance;
        public  static ApplicationViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationViewModel();
                }
                return instance;
            }
        }

        private ViewModelBase mainPage;
        public  ViewModelBase MainPage
        {
            get
            {
                return mainPage;
            }
            set
            {
                mainPage = value;
                OnPropertyChanged("MainPage");
            }
        }

        #endregion

        #region Constructors

        private ApplicationViewModel()
        {
            //TO DO: Manage somehow the userId as a property of this singletone class
            MainPage = HomeLoginViewModel.Instance;
        }

        #endregion
    }
}
