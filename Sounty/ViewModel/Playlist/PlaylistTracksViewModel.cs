using Sounty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class PlaylistCoverImage : ViewModelBase
    {
        private string firstImage;
        private string secondImage;
        private string thirdImage;
        private string fourthImage;

        public string FirstImage
        {
            get => firstImage;
            set
            {
                firstImage = value;
                OnPropertyChanged("FirstImage");
            }
        }

        public string SecondImage
        {
            get => secondImage;
            set
            {
                secondImage = value;
                OnPropertyChanged("SecondImage");
            }
        }

        public string ThirdImage
        {
            get => thirdImage;
            set
            {
                thirdImage = value;
                OnPropertyChanged("ThirdImage");
            }
        }

        public string FourthImage
        {
            get => fourthImage;
            set
            {
                fourthImage = value;
                OnPropertyChanged("FourthImage");
            }
        }
    }


    public class PlaylistViewModel : ViewModelBase
    {
        #region Fields

        private string searchText;
        public PlaylistModel playlistModel;

        RelayCommand searchCommand;
        RelayCommand playPlaylist;
        RelayCommand editPlaylistInfo;

        #endregion

        #region Constructor

        public PlaylistViewModel()
        {
        }

        public static bool PopulatePlaylistViewModel(PlaylistViewModel viewModel, int playlistId)
        {
            try
            {
                viewModel.playlistModel = new PlaylistModel(playlistId);
                viewModel.PlaylistCoverImages = new PlaylistCoverImage();

                viewModel.ShowAllTracks(playlistId);
                viewModel.ShowCoverPhotos();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void ShowCoverPhotos()
        {
            if (playlistModel.ImageCoverId != 0)
            {
                FourCoverPhotosVisibility = false;
                OneCoverPhotoVisibility = true;

                PlaylistCoverImages =
                new PlaylistCoverImage
                {
                    FirstImage = ImagesModel.Instance.GetImagePath(playlistModel.ImageCoverId),
                };

            }
            else if (playlistModel.ImagesCoverId.Count >= 4)
            {
                FourCoverPhotosVisibility = true;
                OneCoverPhotoVisibility = false;

                PlaylistCoverImages =
                new PlaylistCoverImage
                {
                    FirstImage = ImagesModel.Instance.GetImagePath(playlistModel.ImagesCoverId[0]),
                    SecondImage = ImagesModel.Instance.GetImagePath(playlistModel.ImagesCoverId[1]),
                    ThirdImage = ImagesModel.Instance.GetImagePath(playlistModel.ImagesCoverId[2]),
                    FourthImage = ImagesModel.Instance.GetImagePath(playlistModel.ImagesCoverId[3])

                };
            }
            else
            {
                FourCoverPhotosVisibility = false;
                OneCoverPhotoVisibility = true;

                PlaylistCoverImages =
                new PlaylistCoverImage
                {
                    FirstImage = ImagesModel.Instance.GetImagePath(playlistModel.ImagesCoverId[0]),
                };
            }

        }

        void ShowAllTracks(int playlistId)
        {
            using (var context = new DataAccess.SountyDB())
            {
                var list = new List<TrackOfPlaylistViewModel>();

                var results = from c in context.PlaylistTracks
                              where c.playlistId == playlistId
                              select new
                              {
                                  c.trackId
                              };

                foreach (var item in results)
                {
                    var trackName = (from d in context.Tracks
                                     where d.trackId == item.trackId
                                     select new
                                     {
                                         d.trackId,
                                         d.albumId,
                                         d.filepath,
                                         d.nameTrack
                                     }).First();

                    var trackArtists = (from artists in context.TrackArtists
                                        where artists.trackId == trackName.trackId
                                        select artists.artistId);

                    string artistsNames = String.Empty;

                    foreach (var artistId in trackArtists)
                    {
                        var artistName = (from artistItem in context.Artists
                                          where artistItem.artistId == artistId
                                          select artistItem.fullName).FirstOrDefault();
                        artistsNames += artistName + " ";
                    }

                    string albumName = String.Empty;

                    albumName = (from album in context.Albums
                                 where album.albumId == trackName.albumId
                                 select album.albumName).FirstOrDefault();

                    TrackOfPlaylistViewModel track = new TrackOfPlaylistViewModel
                    {
                        TrackName = trackName.nameTrack,
                        Artist = artistsNames,
                        Album = albumName,
                        FilePath = trackName.filepath
                    };

                    list.Add(track);
                }

                AllTracks = new ObservableCollection<TrackOfPlaylistViewModel>(list);
            };
        }

        #endregion

        /// <summary>
        /// Returns a collection of all tracks from PlaylistViewModel objects
        /// </summary>
        private ObservableCollection<TrackOfPlaylistViewModel> allTracks = new ObservableCollection<TrackOfPlaylistViewModel>();
        public ObservableCollection<TrackOfPlaylistViewModel> AllTracks
        {
            get
            {
                if (allTracks == null)
                    allTracks = new ObservableCollection<TrackOfPlaylistViewModel>();

                return allTracks;
            }
            set
            {
                allTracks = value;
                OnPropertyChanged("AllTracks");
            }
        }

        private TrackOfPlaylistViewModel selectedTrack;
        public TrackOfPlaylistViewModel SelectedTrack
        {
            get => selectedTrack;
            set
            {
                selectedTrack = value;
                OnPropertyChanged("SelectedTrack");
            }
        }

        #region Base Class Overrides

        protected override void OnDispose()
        {
            foreach (TrackOfPlaylistViewModel track in this.AllTracks)
                track.Dispose();

            this.AllTracks.Clear();
        }
        #endregion

        #region Binding Values

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        private PlaylistCoverImage playlistCoverImages;

        public PlaylistCoverImage PlaylistCoverImages
        {
            get => playlistCoverImages;
            set
            {
                playlistCoverImages = value;
                OnPropertyChanged("PlaylistCoverImages");
            }
        }

        public string PlaylistName
        {
            get => playlistModel.PlaylistName;
            set
            {
                playlistModel.PlaylistName = value;
                OnPropertyChanged("PlaylistName");
            }
        }

        public string Description
        {
            get => playlistModel.Description;
            set
            {
                playlistModel.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string CreatedBy
        {
            get
            {
                return playlistModel.User.UserName + " ";
            }
        }

        public string NumberOfSongs
        {
            get
            {
                return "• " + AllTracks.Count.ToString() + " songs";
            }
        }

        public string NumberOfFollowers
        {
            get
            {
                return playlistModel.NrFollowers.ToString();
            }
        }

        #endregion

        #region Binding Visibilities

        private bool onePhotoCoverVisibility = false;

        public bool OneCoverPhotoVisibility
        {
            get => onePhotoCoverVisibility;
            set
            {
                onePhotoCoverVisibility = value;
                OnPropertyChanged("OneCoverPhotoVisibility");
            }
        }

        private bool fourCoverPhotosVisibility = true;

        public bool FourCoverPhotosVisibility
        {
            get => fourCoverPhotosVisibility;
            set
            {
                fourCoverPhotosVisibility = value;
                OnPropertyChanged("FourCoverPhotosVisibility");
            }
        }

        private bool errorSearchingVisibility = false;

        public bool ErrorSearchingVisibility
        {
            get => errorSearchingVisibility;
            set
            {
                errorSearchingVisibility = value;
                OnPropertyChanged("ErrorSearchingVisibility");
            }
        }

        #endregion

        #region Commands

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(t => this.SearchSong());
                return searchCommand;
            }
        }

        void SearchSong()
        {
            if (String.IsNullOrEmpty(SearchText) || SearchText.Count() < 1)
            {
                ErrorSearchingVisibility = true;
                return;
            }

            foreach (var track in AllTracks)
            {
                if (track.TrackName.Contains(SearchText))
                {
                    ErrorSearchingVisibility = false;
                    return;
                }
            }

            ErrorSearchingVisibility = true;
        }

        public ICommand PlayPlaylist
        {
            get
            {
                if (playPlaylist == null)
                    playPlaylist = new RelayCommand(t => this.PlayCurrentPlaylist());

                return playPlaylist;
            }
        }

        void PlayCurrentPlaylist()
        {
            List<TrackOfPlaylistViewModel> tracks
                        = new List<TrackOfPlaylistViewModel>(allTracks);
            PlayerViewModel.Instance.Init(tracks);
        }

        public ICommand EditPlaylistInfo
        {
            get
            {
                if (editPlaylistInfo == null)
                    editPlaylistInfo = new RelayCommand(t => this.EditPlaylist());

                return editPlaylistInfo;
            }
        }

        void EditPlaylist()
        {
            var viewModel = new EditPlaylistDialogViewModel(this);

            bool? result = ApplicationViewModel.Instance.dialogService.ShowDialog(viewModel);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    // if ok is pressed
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
