using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sounty.ViewModel
{
    class SongsViewModel : ViewModelBase
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

        public SongsViewModel(int artistId)
        {
            Songs = new ObservableCollection<TrackOfPlaylistViewModel>();
            Load_Songs(artistId);
        }

        #endregion

        #region Methods

        private void Load_Songs(int artistId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from t in context.TrackArtists
                                  where t.artistId == artistId
                                  select new
                                  {
                                      t.Track.Image.imagePath,
                                      t.Track.Album.Artist.fullName,
                                      t.Track.Album.albumName,
                                      t.Track.nameTrack,
                                      t.Track.filepath
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

        #endregion
    }
}
