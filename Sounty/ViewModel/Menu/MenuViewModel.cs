using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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

        public RelayCommand ShowHomePageCMD         { get; }
        public RelayCommand ShowBrowsePageCMD       { get; }
        public RelayCommand ShowRadioPageCMD        { get; }
        public RelayCommand CreatePlaylistCommand   { get; }

        #endregion

        #region Constructors

        private MenuViewModel()
        {
            PlaylistsList = new ObservableCollection<MenuItemViewModel>();

            ShowHomePageCMD         = new RelayCommand(param => ShowHomePage());
            ShowBrowsePageCMD       = new RelayCommand(param => ShowBrowsePage());
            ShowRadioPageCMD        = new RelayCommand(param => ShowRadioPage());
            CreatePlaylistCommand   = new RelayCommand(param => CreatePlaylist());

            Load_PlaylistsList();
        }

        #endregion

        #region Methods

        public static void Reset()
        {
            instance = null;
        }

        public void Load_PlaylistsList()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from playlist in context.Playlists
                                  where playlist.userId == UserRightSideViewModel.Instance.userInfo.userInfoId
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

        private void CreatePlaylist()
        {
            var viewModel = new EditPlaylistDialogViewModel();

            bool? result = ApplicationViewModel.Instance.dialogService.ShowDialog(viewModel);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    if(PlaylistsList.Any(p => p.PlaylistName == viewModel.PlaylistName))
                    {
                        MessageBox.Show("This playlist already exists", "Attention", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            using (var context = new DataAccess.SountyDB())
                            {

                                var newPlaylist = new DataAccess.Playlist
                                {
                                    playlistName = viewModel.PlaylistName,
                                    createdDate = DateTime.Now,
                                    updatedDate = DateTime.Now,
                                    userId = UserRightSideViewModel.Instance.userInfo.userInfoId,
                                    followers = 0,
                                    descriptionText = viewModel.PlaylistDescription,
                                };

                                context.Playlists.Add(newPlaylist);
                                context.SaveChanges();

                                PlaylistsList.Add(new MenuItemViewModel(newPlaylist.playlistName,newPlaylist.playlistId));
                            }

                        }
                        catch(Exception e)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    // If cancel is pressed
                }
            }
        }


        #endregion
    }
}
