using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sounty.ViewModel
{
    class GenrePlaylistViewModel : ViewModelBase
    {
        #region Properties

        public string GenreImage    { get; private set; }
        public string GenreName     { get; private set; }

        private TrackOfPlaylistViewModel selectedSong;
        public  TrackOfPlaylistViewModel SelectedSong
        {
            get
            {
                return selectedSong;
            }
            set
            {
                selectedSong = value;
                OnPropertyChanged("SelectedSong");
            }
        }

        public ObservableCollection<TrackOfPlaylistViewModel> Songs { get; }

        #endregion

        #region Commands

        public RelayCommand PlayCMD { get; }

        #endregion

        #region Constructors

        public GenrePlaylistViewModel(int genrePlayslistId)
        {
            Load_Data(genrePlayslistId);

            Songs = new ObservableCollection<TrackOfPlaylistViewModel>();
            Load_Songs(genrePlayslistId);

            PlayCMD = new RelayCommand(param => Play());
        }

        #endregion

        #region Methods

        private void Load_Data(int genrePlaylistId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var result = (from p in context.PlaylistsGenres
                                  where p.playlistId == genrePlaylistId
                                  select new
                                  {
                                      p.playlistName,
                                      p.Image.imagePath
                                  }).Single();

                    GenreImage  = result.imagePath;
                    GenreName   = result.playlistName;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Load_Songs(int genrePlayslistId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from p in context.PlaylistsGenresTracks
                                  where p.playlistId == genrePlayslistId
                                  select new
                                  {
                                      p.Track.Image.imagePath,
                                      p.Track.Album.Artist.fullName,
                                      p.Track.Album.albumName,
                                      p.Track.nameTrack,
                                      p.Track.filepath
                                  };

                    foreach (var result in results)
                    {
                        Songs.Add(new TrackOfPlaylistViewModel()
                        {
                            ImagePath   = result.imagePath,
                            Artist      = result.fullName,
                            Album       = result.albumName,
                            TrackName   = result.nameTrack,
                            FilePath    = result.filepath
                        });
                    }
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
                new List<TrackOfPlaylistViewModel>(Songs);
            PlayerViewModel.Instance.Init(tracks);
        }

        #endregion
    }
}
