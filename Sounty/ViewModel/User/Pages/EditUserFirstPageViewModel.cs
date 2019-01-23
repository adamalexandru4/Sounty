using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class EditUserFirstPageViewModel : ViewModelBase
    {
        #region Private fields

        private RelayCommand manageSubscription;
        private RelayCommand signOutCommand;
        
        #endregion

        #region Constructor

        public EditUserFirstPageViewModel()
        {

        }

        #endregion

        #region Bindings

        public bool NotPremiumVisibility
        {
            get => UserRightSideViewModel.Instance.NotPremiumVisibility;
            set
            {
                UserRightSideViewModel.Instance.NotPremiumVisibility = value;
                OnPropertyChanged("NotPremiumVisibility");
            }
        }

        public bool PremiumVisibility
        {
            get => UserRightSideViewModel.Instance.PremiumVisibility;
            set
            {
                UserRightSideViewModel.Instance.PremiumVisibility = true;
                OnPropertyChanged("PremiumVisibility");
            }
        }

        public string SubscriptionDate
        {
            get
            {
                var text = "Your plan will expires on ";

                if (UserRightSideViewModel.Instance.expiresDate != DateTime.MinValue)
                {
                    var date = UserRightSideViewModel.Instance.expiresDate;
                    text += date.Day + @"/" + date.Month + @"/" + date.Year;
                }

                return text;
            }
        }

        public string Username
        {
            get => UserRightSideViewModel.Instance.userSounty.userName;
        }

        public string FullName
        {
            get => UserRightSideViewModel.Instance.FirstName + " " + UserRightSideViewModel.Instance.LastName;
        }

        public string Address
        {
            get => UserRightSideViewModel.Instance.userInfo.userAddress;
        }

        public string PhoneNumber
        {
            get => UserRightSideViewModel.Instance.userInfo.phoneNumber;
        }

        public string BirthDate
        {
            get
            {
                string text = string.Empty;
                var date = UserRightSideViewModel.Instance.userInfo.birthDate ?? DateTime.MinValue;
                if (date != DateTime.MinValue)
                {
                    text += date.Day + @"/" + date.Month + @"/" + date.Year;
                }
                return text;
            }
        }
        #endregion

        #region Commands

        public ICommand SubscriptionCommand
        {
            get
            {
                if (manageSubscription == null)
                    manageSubscription = new RelayCommand(t => this.Subscription());

                return manageSubscription;
            }
        }

        void Subscription()
        {
            EditUserViewModel.Instance.UserPage = new SubscriptionViewModel();
        }

        public ICommand SignOutCommand
        {
            get
            {
                if (signOutCommand == null)
                    signOutCommand = new RelayCommand(t => this.SignOut());

                return signOutCommand;
            }
        }

        void SignOut()
        {
            using (var context = new DataAccess.SountyDB())
            {
                var user = (from userItem in context.UserInfoes
                            where userItem.userInfoId == UserRightSideViewModel.Instance.userInfo.userInfoId
                            select userItem).Single();

                user.lastLogin = DateTime.Now;
                user.activeStatus = false;
                context.SaveChanges();

                // RESET EVERYTHING
                UserRightSideViewModel.Reset();
                ChangePasswordViewModel.Reset();
                EditUserViewModel.Reset();
                MainWindowViewModel.Reset();

                ApplicationViewModel.Instance.MainPage = HomeLoginViewModel.Instance;
            }
        }
        #endregion
    }
}
