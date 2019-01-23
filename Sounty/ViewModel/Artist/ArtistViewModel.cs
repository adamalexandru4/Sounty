using System;
using System.Collections.Generic;
using System.Linq;

namespace Sounty.ViewModel
{
    class ArtistViewModel : ViewModelBase
    {
        #region Fields

        private readonly SongsViewModel songs;
        private readonly AboutViewModel about;
        private readonly ConcertsViewModel concerts;

        private string biography;

        #endregion

        #region Properties

        public string ArtistImage   { get; private set; }
        public string ArtistName    { get; private set; }

        private ViewModelBase currentPage;
        public  ViewModelBase CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        #endregion

        #region Commands

        public RelayCommand PlayCMD     { get; }
        public RelayCommand SongsCMD    { get; }
        public RelayCommand AboutCMD    { get; }

        #endregion

        #region Constructors

        public ArtistViewModel(int artistId)
        {
            Load_ArtistData(artistId);

            songs       = new SongsViewModel(artistId);
            about       = new AboutViewModel(biography, artistId);

            CurrentPage = songs;

            PlayCMD     = new RelayCommand(param => Play());
            SongsCMD    = new RelayCommand(param => SwitchToSongs());
            AboutCMD    = new RelayCommand(param => SwitchToAbout());
        }

        #endregion

        #region Methods

        private void Load_ArtistData(int artistId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var result = (from a in context.Artists
                                  where a.artistId == artistId
                                  select new
                                  {
                                      a.fullName,
                                      a.Image.imagePath,
                                      a.biography
                                  }).Single();

                    ArtistName  = result.fullName;
                    ArtistImage = result.imagePath;
                    biography   = result.biography;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Play()
        {
            List<TrackOfPlaylistViewModel> tracks =
                new List<TrackOfPlaylistViewModel>(songs.Songs);
            PlayerViewModel.Instance.Init(tracks);
        }

        private void SwitchToSongs() => CurrentPage = songs;

        private void SwitchToAbout() => CurrentPage = about;

        #endregion
    }
}