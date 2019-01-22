using Sounty.Model;
using Sounty.Resources;
using Sounty.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    class HomeLoginViewModel : ViewModelBase
    {

        #region Fields

        private static HomeLoginViewModel   instance;
        public static HomeLoginViewModel    Instance
        {
            get
            {
                if (instance == null)
                    instance = new HomeLoginViewModel();

                return instance;
            }
        }

        public SignupUserModel SignupUserModel { get; set; }

        RelayCommand signUpRequestCommand;
        RelayCommand backFromSignupCommand;

        RelayCommand signUpCommand;
        RelayCommand loginCommand;

        #endregion

        #region Error check

        public readonly IService service;

        #endregion

        #region Constructor

        HomeLoginViewModel()
        {
            if (service == null)
                service = new Service();

            SignupUserModel = new SignupUserModel();
        }

        #endregion

        #region Visibilities

        private bool loadingVisibility = false;

        public bool LoadingVisibility
        {
            get
            {
                return loadingVisibility;
            }
            set
            {
                loadingVisibility = value;
                OnPropertyChanged("LoadingVisibility");
            }
        }

        private bool loadingSignupVisibility = false;

        public bool LoadingSignupVisibility
        {
            get => loadingSignupVisibility;
            set
            {
                loadingSignupVisibility = value;
                OnPropertyChanged("LoadingSignupVisibility");
            }
        }

        private bool loginVisibility = true;

        public bool LoginVisibility
        {
            get
            {
                return loginVisibility;
            }
            set
            {
                loginVisibility = value;
                OnPropertyChanged("LoginVisibility");
            }
        }

        private bool signUpVisibility = false;

        public bool SignUpVisibility
        {
            get
            {
                return signUpVisibility;
            }
            set
            {
                signUpVisibility = value;
                OnPropertyChanged("SignUpVisibility");
            }
        }

        private bool incorrectUsernameVisibility = false;

        public bool IncorrectUsernameVisibility
        {
            get
            {
                return incorrectUsernameVisibility;
            }
            set
            {
                incorrectUsernameVisibility = value;
                OnPropertyChanged("IncorrectUsernameVisibility");
            }
        }

        private bool incorrectPasswordVisibility = false;

        public bool IncorrectPasswordVisibility
        {
            get
            {
                return incorrectPasswordVisibility;
            }
            set
            {
                incorrectPasswordVisibility = value;
                OnPropertyChanged("IncorrectPasswordVisibility");
            }
        }

        #endregion

        #region Bindings Login

        private string usernameLogin;

        public string UsernameLogin
        {
            get
            {
                return usernameLogin;
            }
            set
            {
                usernameLogin = value;
                _validationErrors.Clear();
                OnPropertyChanged("UsernameLogin");
            }
        }

        private async void ValidateUsername(string username)
        {
            const string propertyKey = "UsernameLogin";
            ICollection<string> validationErrors = null;

            /* Call service asynchronously */
            bool isValid = await Task<bool>.Run(() =>
            {
                return service.ValidateUsername(username, true, out validationErrors);
            })
            .ConfigureAwait(false);

            if (!isValid)
            {
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

        private string passwordLogin;

        #endregion

        #region Commands

        public ICommand SignUpRequestCommand
        {
            get
            {
                if (signUpRequestCommand == null)
                    signUpRequestCommand = new RelayCommand(t => this.SignUpRequest());

                return signUpRequestCommand;
            }
        }

        void SignUpRequest()
        {
            IncorrectUsernameVisibility = false;
            IncorrectPasswordVisibility = false;

            LoginVisibility = false;
            SignUpVisibility = true;

            _validationErrors.Clear();
        }

        public ICommand BackFromSignupCommand
        {
            get
            {
                if (backFromSignupCommand == null)
                    backFromSignupCommand = new RelayCommand(t => this.BackFromSignup());

                return backFromSignupCommand;
            }
        }

        void BackFromSignup()
        {
            UsernameLogin = String.Empty;

            SignupUserModel.Dispose();
            SignupUserModel = new SignupUserModel();
            OnPropertyChanged("SignupUserModel");

            _validationErrors.Clear();
            RaiseErrorsChanged("UsernameLogin"); 

            LoginVisibility = true;
            SignUpVisibility = false;
        }

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                    loginCommand = new RelayCommand(t => this.Login(t));

                return loginCommand;
            }
        }

        private void CheckUserDatabase()
        {
            using (var context = new DataAccess.SountyDB())
            {
                if (context.UserSounties.Any(o => o.userName == usernameLogin))
                {
                    var userId = (from item in context.UserSounties
                                  where item.userName == usernameLogin && item.userPass == passwordLogin
                                  select item.userId).FirstOrDefault();

                    if(userId == 0)
                    {
                        IncorrectPasswordVisibility = true;
                        LoadingVisibility = false;
                        return;
                    }

                    var user = (from userItem in context.UserInfoes
                                where userItem.userInfoId == userId
                                select userItem).Single();

                    user.lastLogin = DateTime.Now;
                    user.activeStatus = true;
                    context.SaveChangesAsync();
                    
                    var main = MainWindowViewModel.Instance;
                    MainWindowViewModel.FillUserInfo(userId);
                    ApplicationViewModel.Instance.MainPage = main;

                    LoadingVisibility = false;
                    usernameLogin = String.Empty;
                }
                else
                {
                    IncorrectUsernameVisibility = true;
                    LoadingVisibility = false;
                }
            };
        }

        void Login(object parameter)
        {
            IncorrectUsernameVisibility = false;
            IncorrectPasswordVisibility = false;
            LoadingVisibility = true;
            
            var passwordContainer = parameter as IHavePassword;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.PasswordLogin;
                passwordLogin = ConvertToUnsecureString(secureString);
            }

            CheckUserDatabase();
        }

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        
        public ICommand SignupDoneCommand
        {
            get
            {
                if (signUpCommand == null)
                    signUpCommand = new RelayCommand(t => this.Signup(t));

                return signUpCommand;
            }
        }

        private void UserSignupDatabase(object parameter)
        {
            using (var context = new DataAccess.SountyDB())
            {
                var passwordContainer = parameter as IHavePassword;
                if (passwordContainer != null)
                {
                    var secureString = passwordContainer.PasswordSignup;
                    SignupUserModel.Password = ConvertToUnsecureString(secureString);
                }

                try
                {

                    var trialSubscription = new DataAccess.Subscription
                    {
                        startDate = DateTime.Today,
                        endDate = DateTime.Today.AddDays(30),
                        trialPeriod = true,
                    };
                    context.Subscriptions.Add(trialSubscription);
                    context.SaveChanges();

                    var userInfo = new DataAccess.UserInfo
                    {
                        firstName = SignupUserModel.FirstName,
                        lastName = SignupUserModel.LastName,
                        phoneNumber = SignupUserModel.PhoneNumber,
                        birthDate = SignupUserModel.BirthdayDate,
                        activeStatus = false,
                        subscriptionId = trialSubscription.subscriptionId
                    };

                    context.UserInfoes.Add(userInfo);
                    context.SaveChanges();

                    var userSounty = new DataAccess.UserSounty
                    {
                        userId = userInfo.userInfoId,
                        userName = SignupUserModel.Username,
                        userPass = SignupUserModel.Password
                    };

                    context.UserSounties.Add(userSounty);
                    context.SaveChanges();

                }
                catch(Exception)
                {
                    LoadingSignupVisibility = false;
                }
            };
            LoadingSignupVisibility = false;

            BackFromSignup();
        }

        async void Signup(object parameter)
        {
            LoadingSignupVisibility = true;
            SignupUserModel.Validate(SignupUserModel.Username, "Username");
            SignupUserModel.Validate(SignupUserModel.FirstName, "FirstName");
            SignupUserModel.Validate(SignupUserModel.LastName, "LastName");
            SignupUserModel.Validate(SignupUserModel.PhoneNumber, "PhoneNumber");
            SignupUserModel.Validate(SignupUserModel.BirthdayDate, "BirthdayDate");
            await Task.Delay(1000);

            LoadingSignupVisibility = false;
            if (SignupUserModel.invalidUsername == true ||
                SignupUserModel.invalidFirstName == true ||
                SignupUserModel.invalidLastName == true ||
                SignupUserModel.invalidPhoneNumber == true ||
                SignupUserModel.invalidBirthdayDate == true)
            {
                _validationErrors.Clear();
                return;
            }

            await Task.Run(() => UserSignupDatabase(parameter));
        }
        #endregion
        
    }
}
