using Sounty.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sounty.Model
{
    public class SignupUserModel : ViewModelBase 
    {
        #region Private

        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private string phoneNumber;
        private DateTime birthdayDate = DateTime.Today;

        public bool invalidUsername = false;
        public bool invalidFirstName = false;
        public bool invalidLastName = false;
        public bool invalidPhoneNumber = false;
        public bool invalidBirthdayDate = false;

        #endregion

        #region Constructor

        public SignupUserModel()
        {
        }

        #endregion

        #region Public fields

        public string Username
        {
            get => username;
            set
            {
                username = value;
                //Validate(value, "Username");
                OnPropertyChanged("Username");
            }
        }
        
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }

        public string FirstName
        {
            get => firstname;
            set
            {
                firstname = value;
                //Validate(value, "FirstName");
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => lastname;
            set
            {
                lastname = value;
                //Validate(value, "LastName");
                OnPropertyChanged("LastName");

            }
        }
        
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                //Validate(value, "PhoneNumber");
                OnPropertyChanged("PhoneNumber");
            }
        }

        

        public DateTime BirthdayDate
        {
            get => birthdayDate;
            set
            {
                birthdayDate = value;
                //Validate(value, "BirthdayDate");
                OnPropertyChanged("BirthdayDate");
            }
        }

        public async void Validate(object name, string propertyKey)
        {
            ICollection<string> validationErrors = null;
            /* Call service asynchronously */
            bool isValid = await Task<bool>.Run(() =>
            {
                switch (propertyKey)
                {
                    case "Username":
                        return HomeLoginViewModel.Instance.service.ValidateUsername(name as string, false, out validationErrors);
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
                    case "Username":
                        invalidUsername = true;
                        break;
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
                switch (propertyKey)
                {
                    case "Username":
                        invalidUsername = false;
                        break;
                    case "FirstName":
                        invalidFirstName = false;
                        break;
                    case "LastName":
                        invalidLastName = false;
                        break;
                    case "PhoneNumber":
                        invalidPhoneNumber = false;
                        break;
                    case "BirthdayDate":
                        invalidBirthdayDate = false;
                        break;
                }

                /* Remove all errors for this property */
                _validationErrors.Remove(propertyKey);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
            }

        }


        #endregion

    }
}
