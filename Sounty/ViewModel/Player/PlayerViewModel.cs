using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Threading;

namespace Sounty.ViewModel
{
    class PlayerViewModel : ViewModelBase
    {
        public enum RepeatMode { None, OneSong, AllSongs }

        #region Fields

        private MediaPlayer     mediaPlayer = new MediaPlayer();
        private readonly Random rng         = new Random();
        private DispatcherTimer timer       = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(250)
        };
        private bool isPlaying  = false;
        private bool isDragging = false;
        private RepeatMode repeatMode = RepeatMode.None;
        private bool wasRepeated;

        private TrackOfPlaylistViewModel crrtPlaying;
        private List<TrackOfPlaylistViewModel> nowPlaying;

        #endregion

        #region Properties

        public TrackOfPlaylistViewModel CrrtPlaying
        {
            get
            {
                return crrtPlaying;
            }
            set
            {
                crrtPlaying = value;
                OnPropertyChanged("CrrtPlaying");
            }
        }

        private static PlayerViewModel instance;
        public  static PlayerViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerViewModel();
                }
                return instance;
            }
        }

        private double volume;
        public  double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                mediaPlayer.Volume = value;
                volume             = value;
                OnPropertyChanged("Volume");
            }
        }

        private double position;
        public  double Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        #endregion

        #region Commands

        public RelayCommand PlayCMD     { get; }
        public RelayCommand PauseCMD    { get; }
        public RelayCommand StopCMD     { get; }
        public RelayCommand PreviousCMD { get; }
        public RelayCommand NextCMD     { get; }
        public RelayCommand ShuffleCMD  { get; }
        public RelayCommand RepeatCMD   { get; }
        public RelayCommand UnmuteCMD   { get; }
        public RelayCommand MuteCMD     { get; }

        #endregion

        #region Constructors

        private PlayerViewModel()
        {
            mediaPlayer.MediaEnded += PlayNextSong;

            timer.Tick += new EventHandler(UpdateSeekBar);
            timer.Tick += new EventHandler(CheckForSignOut);

            Volume = 0.5;
            Position = 0;

            PlayCMD     = new RelayCommand(param => Play(),     param => CanUsePlayer());
            PauseCMD    = new RelayCommand(param => Pause(),    param => CanUsePlayer());
            StopCMD     = new RelayCommand(param => Stop(),     param => CanUsePlayer());
            PreviousCMD = new RelayCommand(param => Previous(), param => CanUsePlayer());
            NextCMD     = new RelayCommand(param => Next(),     param => CanUsePlayer());
            ShuffleCMD  = new RelayCommand(param => Shuffle(),  param => CanUsePlayer());
            RepeatCMD   = new RelayCommand(param => Repeat(),   param => CanUsePlayer());
            UnmuteCMD   = new RelayCommand(param => Unmute());
            MuteCMD     = new RelayCommand(param => Mute());
        }

        #endregion

        #region Methods

        public void Init(List<TrackOfPlaylistViewModel> tracks)
        {
            if (tracks.Count == 0) return;

            CrrtPlaying = tracks[0];
            nowPlaying  = tracks;

            mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
            Play();
        }

        private void PlayNextSong(object sender, EventArgs eventArgs)
        {
            if (repeatMode == RepeatMode.None)
            {
                int crrtIndex = nowPlaying.IndexOf(CrrtPlaying);
                if (crrtIndex == nowPlaying.Count - 1) return;
                else
                {
                    CrrtPlaying = nowPlaying[crrtIndex + 1];
                }
                mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
                mediaPlayer.Play();
            }
            else
            if (repeatMode == RepeatMode.OneSong)
            {
                mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
                mediaPlayer.Play();

                repeatMode = RepeatMode.None;
            }
            else
            if (repeatMode == RepeatMode.AllSongs)
            {
                if (wasRepeated)
                {
                    int crrtIndex = nowPlaying.IndexOf(CrrtPlaying);
                    if (crrtIndex == nowPlaying.Count - 1) return;
                    else
                    {
                        CrrtPlaying = nowPlaying[crrtIndex + 1];
                    }
                    mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
                    mediaPlayer.Play();

                    wasRepeated = false;
                }
                else
                {
                    mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
                    mediaPlayer.Play();

                    wasRepeated = true;
                }
            }
        }

        private bool CanUsePlayer()
        {
            if (CrrtPlaying != null &&
                nowPlaying  != null &&
                nowPlaying.Count != 0)
            {
                return true;
            }
            return false;
        }

        private void Play()
        {
            mediaPlayer.Play();
            timer.Start();
            isPlaying = true;
        }

        private void Pause()
        {
            mediaPlayer.Pause();
            timer.Stop();
            isPlaying = false;
        }

        private void Stop()
        {
            mediaPlayer.Stop();
            timer.Stop();
            isPlaying = false;

            Position = 0;
        }

        private void Previous()
        {
            int crrtIndex = nowPlaying.IndexOf(CrrtPlaying);

            if (crrtIndex == 0) CrrtPlaying = nowPlaying[nowPlaying.Count - 1];
            else                CrrtPlaying = nowPlaying[crrtIndex - 1];

            timer.Stop();
            Position = 0;

            mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
            if (isPlaying) Play();
        }

        private void Next()
        {
            int crrtIndex = nowPlaying.IndexOf(CrrtPlaying);

            if (crrtIndex == nowPlaying.Count - 1) CrrtPlaying = nowPlaying[0];
            else                                   CrrtPlaying = nowPlaying[crrtIndex + 1];

            timer.Stop();
            Position = 0;

            mediaPlayer.Open(new Uri(CrrtPlaying.FilePath));
            if (isPlaying) Play();
        }

        private void Shuffle()
        {
            int i = nowPlaying.Count;
            int j;
            TrackOfPlaylistViewModel value;

            while (i > 1)
            {
                --i;
                j = rng.Next(i + 1);
                value         = nowPlaying[j];
                nowPlaying[j] = nowPlaying[i];
                nowPlaying[i] = value;
            }
        }

        private void Repeat()
        {
            switch (repeatMode)
            {
                case RepeatMode.None:    repeatMode = RepeatMode.OneSong;  break;
                case RepeatMode.OneSong: repeatMode = RepeatMode.AllSongs; break;
                case RepeatMode.AllSongs:
                    {
                        repeatMode  = RepeatMode.None;
                        wasRepeated = false;
                    }
                    break;
            }
        }

        private void Unmute() => Volume = 0.5;
        private void Mute()   => Volume = 0;

        public void UpdateSeekBar(object sender, EventArgs eventArgs)
        {
            if (!isDragging)
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    Position =
                        mediaPlayer.Position.TotalSeconds /
                        mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                }
            }
        }

        public void SeekBarDragStarted() => isDragging = true;

        public void SeekBarDragCompleted()
        {
            isDragging = false;

            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                mediaPlayer.Position =
                    TimeSpan.FromSeconds
                    (
                        Position *
                        mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds
                    );
            }
            else Position = 0;
        }

        public void CheckForSignOut(object sender, EventArgs eventArgs)
        {
            if (ApplicationViewModel.Instance.MainPage is HomeLoginViewModel)
            {
                CrrtPlaying = null;
                nowPlaying.Clear();

                Stop();
                mediaPlayer.Close();
                repeatMode = RepeatMode.None;
            }
        }

        #endregion
    }
}
