namespace Sounty.ViewModel
{
    class MenuItemViewModel
    {
        #region Properties

        public string PlaylistName { get; set; }
        public int PlaylistId { get; set; }

        #endregion

        #region Commands

        public RelayCommand ShowPlaylistCMD { get; private set; }

        #endregion

        #region Constructors

        public MenuItemViewModel(string playlistName, int playlistId)
        {
            PlaylistName = playlistName;
            PlaylistId = playlistId;

            ShowPlaylistCMD = new RelayCommand(param => ShowPlaylist(param));
        }

        #endregion

        #region Methods

        private void ShowPlaylist(object playlistId)
        {
            if (playlistId is int)
            {
                MainWindowViewModel.Instance.Workspace = new LoadingWorkspaceViewModel();

                var playlist = new PlaylistViewModel();
                bool isValid = PlaylistViewModel.PopulatePlaylistViewModel(playlist, (int)playlistId);
                if (isValid == true)
                {
                    MainWindowViewModel.Instance.Workspace = playlist;
                }
            }
        }

        #endregion
    }
}
