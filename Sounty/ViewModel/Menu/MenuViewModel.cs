using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sounty.ViewModel
{
    class MenuViewModel : ViewModelBase
    {
        #region Properties

        private static MenuViewModel instance;
        public  static MenuViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuViewModel();
                }
                return instance;
            }
        }

        private MenuItemViewModel selectedPlaylist;
        public  MenuItemViewModel SelectedPlaylist
        {
            get
            {
                return selectedPlaylist;
            }
            set
            {
                selectedPlaylist = value;
                OnPropertyChanged("SelectedPlaylist");
            }
        }

        private ObservableCollection<MenuItemViewModel> playlistsList;
        public  ObservableCollection<MenuItemViewModel> PlaylistsList
        {
            get
            {
                return playlistsList;
            }
            set
            {
                playlistsList = value;
                OnPropertyChanged("PlaylistsList");
            }
        }

        #endregion

        #region Commands

        public RelayCommand ShowHomePageCMD   { get; }
        public RelayCommand ShowBrowsePageCMD { get; }
        public RelayCommand ShowRadioPageCMD  { get; }

        #endregion

        #region Constructors

        private MenuViewModel()
        {
            PlaylistsList = new ObservableCollection<MenuItemViewModel>();

            ShowHomePageCMD   = new RelayCommand(param => ShowHomePage());
            ShowBrowsePageCMD = new RelayCommand(param => ShowBrowsePage());
            ShowRadioPageCMD  = new RelayCommand(param => ShowRadioPage());

            Load_PlaylistsList();
        }

        #endregion

        #region Methods

        public void Load_PlaylistsList()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from playlist in context.Playlists
                                  select new
                                  {
                                      playlist.playlistName,
                                      playlist.playlistId
                                  };

                    foreach (var result in results)
                    {
                        PlaylistsList.Add(
                            new MenuItemViewModel(
                                result.playlistName,
                                result.playlistId));
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ShowHomePage()
        {
            MainWindowViewModel.Instance.Workspace = new HomeViewModel();

            SelectedPlaylist = null;
        }

        private void ShowBrowsePage()
        {

        }

        private void ShowRadioPage()
        {
            
        }

        #endregion
    }
}
