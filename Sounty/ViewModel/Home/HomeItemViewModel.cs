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

        #endregion

        #region Properties

        public int    CoverId   { get; set; }
        public string CoverPath { get; set; }
        public string CoverName { get; set; }

        #endregion

        #region Commands

        public RelayCommand PlayCMD { get; }
        public RelayCommand OpenCMD { get; }

        #endregion

        #region Constructors

        public HomeItemViewModel(CoverType type, int coverId, string coverPath, string coverName)
        {
            this.type = type;
            CoverId   = coverId;
            CoverPath = coverPath;
            CoverName = coverName;

            PlayCMD = new RelayCommand(param => Play());
            OpenCMD = new RelayCommand(param => Open());
        }

        #endregion

        #region Methods

        private void Play()
        {
            switch (type)
            {
                case CoverType.GenrePlaylist:
                    {
                        try
                        {
                            using (var context = new DataAccess.SountyDB())
                            {
                                var results = from p in context.PlaylistsGenresTracks
                                              join t in context.Tracks
                                              on p.trackId equals t.trackId
                                              join i in context.Images
                                              on t.imageId equals i.imageId
                                              select new
                                              {
                                                  t.filepath,
                                                  t.nameTrack,
                                                  i.imagePath
                                              };

                                List<TrackModel> tracks = new List<TrackModel>();
                                foreach (var result in results)
                                {
                                    tracks.Add(
                                        new TrackModel(
                                            result.filepath,
                                            result.nameTrack,
                                            result.imagePath));
                                }
                                PlayerViewModel.Instance.Init(tracks);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    } break;
                case CoverType.ArtistPlaylist:
                    {
                        try
                        {

                        }
                        catch (Exception)
                        {
                            return;
                        }
                    } break;
            }
        }

        private void Open()
        {

        }

        #endregion
    }
}
