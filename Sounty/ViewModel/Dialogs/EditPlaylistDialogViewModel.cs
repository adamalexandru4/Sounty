using Microsoft.Win32;
using Sounty.Resources;
using Sounty.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class EditPlaylistDialogViewModel : ViewModelBase, IDialogRequestClose
    {
        #region IDialog interface

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion

        #region Fields
        const string NoImagePath = @"/Resources/Images/NoImage.png";
        int newCoverPhotoId;

        private string newCoverPath;

        private PlaylistViewModel playlistViewModel;

        public PlaylistViewModel PlaylistViewModel
        {
            get => playlistViewModel;
            set
            {
                playlistViewModel = value;
                OnPropertyChanged("PlaylistViewModel");
            }
        }

        #endregion

        #region Constructor

        public EditPlaylistDialogViewModel(PlaylistViewModel playlistViewModel)
        {
            this.PlaylistViewModel = playlistViewModel;

            newPlaylistName         = playlistViewModel.PlaylistName;
            newPlaylistDescription  = playlistViewModel.Description;

            if(playlistViewModel.playlistModel.ImageCoverId != 0)
            {
                CoverPhotoPath = playlistViewModel.PlaylistCoverImages.FirstImage;
            }
            else
            {
                CoverPhotoPath = NoImagePath;
            }
        }

        #endregion

        #region Bindings

        private string newPlaylistName;

        public string PlaylistName
        {
            get => newPlaylistName;
            set
            {
                newPlaylistName = value;
                OnPropertyChanged("PlaylistName");
            }
        }

        private string newPlaylistDescription;

        public string PlaylistDescription
        {
            get => newPlaylistDescription;
            set
            {
                newPlaylistDescription = value;
                OnPropertyChanged("PlaylistDescription");
            }
        }

        private string coverPhotoPath;

        public string CoverPhotoPath
        {
            get => coverPhotoPath;
            set
            {
                coverPhotoPath = value;
                OnPropertyChanged("CoverPhotoPath");
            }
        }

        #endregion

        #region Commands

        RelayCommand saveCommand;
        RelayCommand cancelCommand;
        RelayCommand choosePlaylistCover;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(t => this.Save());

                return saveCommand;
            }
        }

        void Save()
        {
            string oldName = playlistViewModel.PlaylistName;

            playlistViewModel.PlaylistName  = newPlaylistName;
            playlistViewModel.Description   = newPlaylistDescription;

            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var newImage = new DataAccess.Image
                    {
                        imageName = "Cover playlist " + playlistViewModel.PlaylistName,
                        imagePath = coverPhotoPath
                    };

                    var imageDB = (from image in context.Images
                                   where image.imageName == ("Cover playlist " + playlistViewModel.PlaylistName)
                                   select image).FirstOrDefault();

                    if (imageDB == null)
                    {
                        context.Images.Add(newImage);
                    }
                    else
                    {
                        imageDB.imagePath = newImage.imagePath;
                        newImage.imageId = imageDB.imageId;
                    }
                    context.SaveChanges();

                    var getPlaylist = (from playlist in context.Playlists
                                       where playlist.playlistId == playlistViewModel.playlistModel.PlaylistId
                                       select playlist).Single();

                    getPlaylist.imageId = newImage.imageId;
                    newCoverPhotoId = newImage.imageId;
                    context.SaveChanges();

                    PlaylistViewModel.playlistModel.ImageCoverId = newImage.imageId;
                    CoverPhotoPath = newImage.imagePath;
                };
            }
            catch (Exception e)
            {
                return;
            }

            if (CoverPhotoPath != NoImagePath)
            {
                playlistViewModel.PlaylistCoverImages.FirstImage = CoverPhotoPath;
                
                PlaylistViewModel.PlaylistCoverImages.SecondImage =
                    PlaylistViewModel.PlaylistCoverImages.ThirdImage =
                    PlaylistViewModel.PlaylistCoverImages.FourthImage = String.Empty;

                PlaylistViewModel.OneCoverPhotoVisibility = true;
                PlaylistViewModel.FourCoverPhotosVisibility = false;
            }
            try
            {
                // Changing playlist list name in the left side of the app
                //var elem = MainWindowViewModel.Instance.PlaylistList.First(t => t.DisplayName == oldName);
                //if(elem != null)
                //{
                //    elem.PlaylistName = newPlaylistName;
                //}

                using (var context = new DataAccess.SountyDB())
                {
                    var c = (from playlist in context.Playlists
                             where playlist.playlistId == playlistViewModel.playlistModel.PlaylistId
                             select playlist).Single();

                    c.playlistName = playlistViewModel.PlaylistName;
                    c.descriptionText = playlistViewModel.Description;

                    context.SaveChanges();
                };
            }
            catch(Exception)
            {
                return;
            }


            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new RelayCommand(t => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));

                return cancelCommand;
            }
        }

        public ICommand ChoosePlaylistCover
        {
            get
            {
                if (choosePlaylistCover == null)
                    choosePlaylistCover = new RelayCommand(t => this.ChangeCover());

                return choosePlaylistCover;
            }
        }

        void ChangeCover()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            openFileDialog.InitialDirectory = projectDirectory;
            
            if (openFileDialog.ShowDialog() ?? false)
            {
                CoverPhotoPath = openFileDialog.FileName;
            }
        }
        #endregion


    }
}
