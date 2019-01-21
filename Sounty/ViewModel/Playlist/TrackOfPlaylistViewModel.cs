using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.ViewModel
{
    public class TrackOfPlaylistViewModel : ViewModelBase
    {
        private string trackName { get; set; }
        private string artist { get; set; }
        private string album { get; set; }
        private string filePath { get; set; }
        private string imagePath { get; set; }


        public TrackOfPlaylistViewModel()
        {

        }

        public TrackOfPlaylistViewModel(string trackName)
        {
            this.trackName = trackName;
            this.artist = artist;
            this.DisplayName = "Playlist";
        }

        public string TrackName
        {
            get { return trackName; }
            set
            {
                if (value == trackName)
                    return;

                trackName = value;
                base.OnPropertyChanged("TrackName");
            }
        }

        public string Album
        {
            get => album;
            set
            {
                album = value;
                OnPropertyChanged("Album");
            }
        }

        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
            }
        }

        public string Artist
        {
            get { return artist; }
            set
            {
                if (value == artist)
                    return;

                artist = value;
                base.OnPropertyChanged("Artist");
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (value == imagePath)
                    return;

                imagePath = value;
                base.OnPropertyChanged("ImagePath");
            }
        }
    }
}
