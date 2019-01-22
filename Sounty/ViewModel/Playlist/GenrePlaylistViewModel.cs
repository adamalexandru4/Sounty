using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sounty.ViewModel
{
    class GenrePlaylistViewModel : ViewModelBase
    {
        #region Properties

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

        #region Constructors

        public GenrePlaylistViewModel(int genrePlayslistId)
        {
            Songs = new ObservableCollection<TrackOfPlaylistViewModel>();
            Load_Songs(genrePlayslistId);
        }

        #endregion

        #region Methods

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
                                      p.Track.nameTrack
                                  };

                    foreach (var result in results)
                    {
                        Songs.Add(new TrackOfPlaylistViewModel()
                        {
                            ImagePath   = result.imagePath,
                            Artist      = result.fullName,
                            Album       = result.albumName,
                            TrackName   = result.nameTrack
                        });
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion
    }
}
