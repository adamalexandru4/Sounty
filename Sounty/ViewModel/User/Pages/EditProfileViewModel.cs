using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class EditProfileViewModel : ViewModelBase
    {
        #region Private fields

        private string newFirstName;
        private string newLastName;
        private string newAddress;
        private string newPhoneNumber;
        private DateTime newBirthDate;
        private string newProfileImagePath;

        private bool loadingSavingVisibility;

        private RelayCommand changeImageCommand;
        private RelayCommand saveCommand;

        private readonly IService service;

        #endregion

        public EditProfileViewModel()
        {
            newFirstName = UserRightSideViewModel.Instance.userInfo.firstName;
            newLastName = UserRightSideViewModel.Instance.userInfo.lastName;
            newAddress = UserRightSideViewModel.Instance.userInfo.userAddress;
            newPhoneNumber = UserRightSideViewModel.Instance.userInfo.phoneNumber;
            newBirthDate = UserRightSideViewModel.Instance.userInfo.birthDate ?? DateTime.Today;
            newProfileImagePath = UserRightSideViewModel.Instance.UserProfileImagePath;

            if(service == null)
                service = new Service();
        }

        #region Bindings

        public string CoverImagePath
        {
            get => EditUserViewModel.Instance.CoverImagePath;
        }

        public string FirstName
        {
            get => newFirstName;
            set
            {
                newFirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => newLastName;
            set
            {
                newLastName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string Address
        {
            get => newAddress;
            set
            {
                newAddress = value;
                OnPropertyChanged("Address");
            }
        }

        public string PhoneNumber
        {
            get => newPhoneNumber;
            set
            {
                newPhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public DateTime BirthDate
        {
            get => newBirthDate;
            set
            {
                newBirthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public string ProfileImagePath
        {
            get => newProfileImagePath;
            set
            {
                newProfileImagePath = value;
                OnPropertyChanged("ProfileImagePath");
            }
        }
        #endregion

        #region Commands

        public ICommand ChangeImageCommand
        {
            get
            {
                if (changeImageCommand == null)
                    changeImageCommand = new RelayCommand(t => ChangeImage());

                return changeImageCommand;
            }
        }

        void ChangeImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            openFileDialog.InitialDirectory = projectDirectory;

            if (openFileDialog.ShowDialog() ?? false)
            {
                ProfileImagePath = openFileDialog.FileName;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new RelayCommand(t => this.Save());

                return saveCommand;
            }
        }

        public bool LoadingSavingVisibility
        {
            get => loadingSavingVisibility;
            set
            {
                loadingSavingVisibility = value;
                OnPropertyChanged("LoadingSavingVisibility");
            }
        }

        private void EditProfileInDatabase()
        {
            using (var context = new DataAccess.SountyDB())
            {
                try
                {
                    var imageFound = (from image in context.Images
                                      where image.imagePath == newProfileImagePath
                                      select image).FirstOrDefault();

                    var newImage = new DataAccess.Image();

                    if (imageFound == null)
                    {
                        newImage = new DataAccess.Image
                        {
                            imageName = newFirstName + " " + newLastName,
                            imagePath = newProfileImagePath
                        };
                        
                        context.Images.Add(newImage);
                        context.SaveChanges();
                    }
                    var userFound = (from user in context.UserInfoes
                                    where user.userInfoId == UserRightSideViewModel.Instance.userInfo.userInfoId
                                    select user).Single();

                    userFound.firstName = newFirstName;
                    userFound.lastName = newLastName;
                    userFound.userAddress = newAddress;
                    userFound.phoneNumber = newPhoneNumber;
                    userFound.birthDate = newBirthDate;
                    userFound.profileImage = imageFound == null ? newImage.imageId : imageFound.imageId;
                    context.SaveChanges();   

                    /* Notify all bindings for this changes */
                    if(UserRightSideViewModel.Instance.UserProfileImagePath != newProfileImagePath)
                        UserRightSideViewModel.Instance.UserProfileImagePath = newProfileImagePath;

                    UserRightSideViewModel.Instance.FirstName   = newFirstName;
                    UserRightSideViewModel.Instance.LastName    = newLastName;
                    EditUserViewModel.Instance.HelloName        = newFirstName;
                    EditUserViewModel.Instance.CoverImagePath   = newProfileImagePath;
                }
                catch (Exception e)
                {
                    LoadingSavingVisibility = false;
                }
            };
        }

        async void Save()
        {
            LoadingSavingVisibility = true;
            Validate(newFirstName, "FirstName");
            Validate(newLastName, "LastName");
            Validate(newPhoneNumber, "PhoneNumber");
            Validate(newBirthDate, "BirthdayDate");
            await Task.Delay(1000);

            LoadingSavingVisibility = false;
            if(invalidFirstName == true ||
                invalidLastName == true ||
                invalidPhoneNumber == true ||
                invalidBirthdayDate == true)
            {

                invalidFirstName = false;
                invalidLastName = false;
                invalidPhoneNumber = false;
                invalidBirthdayDate = false;
                _validationErrors.Clear();
                return;
            }

            await Task.Run(() => EditProfileInDatabase());
        }

        #endregion

        #region Validation
        
        public bool invalidFirstName = false;
        public bool invalidLastName = false;
        public bool invalidPhoneNumber = false;
        public bool invalidBirthdayDate = false;

        public async void Validate(object name, string propertyKey)
        {
            ICollection<string> validationErrors = null;
            /* Call service asynchronously */
            bool isValid = await Task<bool>.Run(() =>
            {
                switch (propertyKey)
                {
                    case "FirstName":
                        return HomeLoginViewModel.Instance.service.ValidateName(name as string, out validationErrors);
                    case "LastName":
                        return HomeLoginViewModel.Instance.service.ValidateName(name as string, out validationErrors);
                    case "PhoneNumber":
                        return HomeLoginViewModel.Instance.service.ValidatePhoneNumber(name as string, out validationErrors);
                    case "BirthdayDate":
                        return HomeLoginViewModel.Instance.service.ValidateBirthdayDate((DateTime)name, out validationErrors);

                }
                return false;
            })
            .ConfigureAwait(false);

            if (!isValid)
            {
                switch (propertyKey)
                {
                    case "FirstName":
                        invalidFirstName = true;
                        break;
                    case "LastName":
                        invalidLastName = true;
                        break;
                    case "PhoneNumber":
                        invalidPhoneNumber = true;
                        break;
                    case "BirthdayDate":
                        invalidBirthdayDate = true;
                        break;
                }

                /* Update the collection in the dictionary returned by the GetErrors method */
                _validationErrors[propertyKey] = validationErrors;
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
            }
            else if (_validationErrors.ContainsKey(propertyKey))
            {
                /* Remove all errors for this property */
                _validationErrors.Remove(propertyKey);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
            }

        }

        #endregion
    }
}
