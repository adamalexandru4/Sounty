using System;
using System.Collections.Generic;
using System.Linq;

using Sounty.Model;

namespace Sounty.ViewModel
{
    public class HomeItemViewModel : ViewModelBase
    {
        public enum CoverType { GenrePlaylist, ArtistPlaylist }

        #region Fields

        private readonly CoverType type;
        private readonly int coverId;

        #endregion

        #region Properties

        public string CoverPath { get; }
        public string CoverName { get; }

        #endregion

        #region Commands

        public RelayCommand PlayCMD { get; }
        public RelayCommand OpenCMD { get; }

        #endregion

        #region Constructors

        public HomeItemViewModel(CoverType type, int coverId, string coverPath, string coverName)
        {
            this.type    = type;
            this.coverId = coverId;
            CoverPath    = coverPath;
            CoverName    = coverName;

            PlayCMD = new RelayCommand(param => Play());
            OpenCMD = new RelayCommand(param => Open());
        }

        #endregion

        #region Methods

        private void PlayGenrePlaylist()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from p in context.PlaylistsGenresTracks
                                  where p.playlistId == coverId
                                  select new
                                  {
                                      p.Track.Image.imagePath,
                                      p.Track.Album.Artist.fullName,
                                      p.Track.Album.albumName,
                                      p.Track.nameTrack,
                                      p.Track.filepath
                                  };

                    List<TrackOfPlaylistViewModel> tracks = new List<TrackOfPlaylistViewModel>();
                    foreach (var result in results)
                    {
                        tracks.Add(
                            new TrackOfPlaylistViewModel()
                            {
                                ImagePath   = result.imagePath,
                                Artist      = result.fullName,
                                Album       = result.albumName,
                                TrackName   = result.nameTrack,
                                FilePath    = result.filepath
                            });
                    }
                    PlayerViewModel.Instance.Init(tracks);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void PlayArtistPlaylist()
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var results = from a in context.TrackArtists
                                  where a.artistId == coverId
                                  select new
                                  {
                                      a.Track.Image.imagePath,
                                      a.Track.Album.Artist.fullName,
                                      a.Track.Album.albumName,
                                      a.Track.nameTrack,
                                      a.Track.filepath
                                  };

                    List<TrackOfPlaylistViewModel> tracks = new List<TrackOfPlaylistViewModel>();
                    foreach (var result in results)
                    {
                        tracks.Add(
                            new TrackOfPlaylistViewModel()
                            {
                                ImagePath   = result.imagePath,
                                Artist      = result.fullName,
                                Album       = result.albumName,
                                TrackName   = result.nameTrack,
                                FilePath    = result.filepath
                            });
                    }
                    PlayerViewModel.Instance.Init(tracks);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Play()
        {
            switch (type)
            {
                case CoverType.GenrePlaylist:   PlayGenrePlaylist();  break;
                case CoverType.ArtistPlaylist:  PlayArtistPlaylist(); break;
            }
        }

        private void Open()
        {
            switch (type)
            {
                case CoverType.GenrePlaylist:
                    {
                        MainWindowViewModel.Instance.Workspace = new GenrePlaylistViewModel(coverId);
                    } break;
                case CoverType.ArtistPlaylist:
                    {
                        MainWindowViewModel.Instance.Workspace = new ArtistViewModel(coverId);
                    } break;
            }
        }

        #endregion
    }
}
