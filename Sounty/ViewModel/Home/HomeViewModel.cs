using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sounty.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<HomeItemViewModel> PlaylistsByGenre     { get; }
        public ObservableCollection<HomeItemViewModel> PlaylistsByArtist    { get; }

        #endregion

        #region Constructors

        public HomeViewModel()
        {
            PlaylistsByGenre    = new ObservableCollection<HomeItemViewModel>();
            PlaylistsByArtist   = new ObservableCollection<HomeItemViewModel>();

            Load_PlaylistsByGenres();
            Load_PlaylistsByArtists();
        }

        #endregion

        #region Methods

        private void Load_PlaylistsByGenres()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from p in context.PlaylistsGenres
                                  join i in context.Images
                                  on p.imageId equals i.imageId
                                  where p.imageId != null
                                  select new
                                  {
                                      p.playlistId,
                                      i.imagePath,
                                      p.playlistName
                                  };

                    foreach (var result in results)
                    {
                        PlaylistsByGenre.Add(
                            new HomeItemViewModel(
                                HomeItemViewModel.CoverType.GenrePlaylist,
                                result.playlistId,
                                result.imagePath,
                                result.playlistName
                                )
                            );
                    }
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void Load_PlaylistsByArtists()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from a in context.Artists
                                  join i in context.Images
                                  on a.imageId equals i.imageId
                                  where a.imageId != null
                                  select new
                                  {
                                      a.artistId,
                                      i.imagePath,
                                      a.fullName
                                  };

                    foreach (var result in results)
                    {
                        PlaylistsByArtist.Add(
                            new HomeItemViewModel(
                                HomeItemViewModel.CoverType.GenrePlaylist,
                                result.artistId,
                                result.imagePath,
                                result.fullName
                                )
                            );
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
