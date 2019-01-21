using Sounty.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        #region Private fields

        private bool loadingSavingVisibility = false;
        private bool invalidCurrentPassword = false;
        private bool notMachingPasswords = false;

        private string oldPassword;
        private string newPassword;
        private string repeatNewPassword;

        private RelayCommand setPassword;

        #endregion

        private static ChangePasswordViewModel instance;
        public static ChangePasswordViewModel  Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChangePasswordViewModel();

                return instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        ChangePasswordViewModel()
        {
        }

        #region Bindings

        public bool LoadingSavingVisibility
        {
            get => loadingSavingVisibility;
            set
            {
                loadingSavingVisibility = value;
                OnPropertyChanged("LoadingSavingVisibility");
            }
        }

        public bool InvalidCurrentPassword
        {
            get => invalidCurrentPassword;
            set
            {
                invalidCurrentPassword = value;
                OnPropertyChanged("InvalidCurrentPassword");
            }
        }

        public bool NotMachingPasswords
        {
            get => notMachingPasswords;
            set
            {
                notMachingPasswords = value;
                OnPropertyChanged("NotMachingPasswords");
            }
        }

        #endregion

        #region Commands

        public ICommand SetPasswordCommand
        {
            get
            {
                if (setPassword == null)
                    setPassword = new RelayCommand(t => this.Save(t));

                return setPassword;
            }
        }

        void Save(object parameter)
        {
            InvalidCurrentPassword = false;
            NotMachingPasswords = false;

            LoadingSavingVisibility = true;

            var passwordContainer = parameter as IHavePasswordChange;
            if (passwordContainer != null)
            {
                var secureString = passwordContainer.OldPassword;
                oldPassword = ConvertToUnsecureString(secureString);

                secureString = passwordContainer.NewPassword;
                newPassword = ConvertToUnsecureString(secureString);

                secureString = passwordContainer.RepeatNewPassword;
                repeatNewPassword = ConvertToUnsecureString(secureString);

                var passwordUser = UserRightSideViewModel.Instance.userSounty.userPass;
                if (passwordUser != oldPassword)
                {
                    passwordContainer.ClearText();
                    LoadingSavingVisibility = false;
                    InvalidCurrentPassword = true;
                    return;
                }

                if (newPassword != repeatNewPassword || String.IsNullOrEmpty(newPassword) || String.IsNullOrEmpty(repeatNewPassword))
                {
                    passwordContainer.ClearText();
                    LoadingSavingVisibility = false;
                    NotMachingPasswords = true;
                    return;
                }

                try
                {
                    using (var context = new DataAccess.SountyDB())
                    {
                        var userSounty = (from user in context.UserSounties
                                    where user.userId == UserRightSideViewModel.Instance.userSounty.userId
                                    select user).Single();

                        userSounty.userPass = newPassword;
                        context.SaveChanges();

                    }
                }
                catch(Exception e)
                {
                    LoadingSavingVisibility = false;
                    return;
                }
                
            }

            passwordContainer.ClearText();
            EditUserViewModel.Instance.UserPage = new EditUserFirstPageViewModel();
            LoadingSavingVisibility = false;
        }
        #endregion

        #region Private Methods

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

        #endregion

    }
}
