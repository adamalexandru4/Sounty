using Sounty.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class SubscriptionItemViewModel : ViewModelBase
    {
        private string name;
        private string feature1;
        private string feature2;
        private string feature3;
        private string price;
        private string image;

        private RelayCommand payCommand;

        public SubscriptionItemViewModel()
        {

        }

        #region Bindings

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public string Feature1
        {
            get => feature1;
            set
            {
                feature1 = value;
                OnPropertyChanged("Feature1");
            }
        }

        public string Feature2
        {
            get => feature2;
            set
            {
                feature2 = value;
                OnPropertyChanged("Feature2");
            }
        }

        public string Feature3
        {
            get => feature3;
            set
            {
                feature3 = value;
                OnPropertyChanged("Feature3");
            }
        }

        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        #endregion

        #region Commands

        public ICommand PayCommand
        {
            get
            {
                if (payCommand == null)
                    payCommand = new RelayCommand(t => this.Pay());

                return payCommand;
            }
        }

        void Pay()
        {
            if (price != "Free" && UserRightSideViewModel.Instance.NotPremiumVisibility == true)
            {
                var viewModel = new PaySubscriptionDialogViewModel();

                bool? result = ApplicationViewModel.Instance.dialogService.ShowDialog(viewModel);
                if (result.HasValue)
                {
                    if (result.Value)
                    {
                        try
                        {
                            using (var context = new DataAccess.SountyDB())
                            {
                                var newPayment = new DataAccess.Payment
                                {
                                    cardNumber = viewModel.CreditCardNumber,
                                    cardHolder = viewModel.CardHolderName,
                                    expirationYear = viewModel.ExpirationDate.Year,
                                    expirationMonth = viewModel.ExpirationDate.Month
                                    
                                };

                                context.Payments.Add(newPayment);
                                context.SaveChanges();

                                var newSubscription = new DataAccess.Subscription
                                {
                                    startDate = DateTime.Today,
                                    endDate = DateTime.Today.AddDays(30),
                                    trialPeriod = false,
                                    paymentId = newPayment.cardId
                                };

                                context.Subscriptions.Add(newSubscription);
                                context.SaveChanges();

                                var user = (from userItem in context.UserInfoes
                                            where userItem.userInfoId == UserRightSideViewModel.Instance.userInfo.userInfoId
                                            select userItem).Single();

                                user.subscriptionId = newSubscription.subscriptionId;
                                context.SaveChanges();
                            }
                            
                            UserRightSideViewModel.Instance.NotPremiumVisibility = false;
                            UserRightSideViewModel.Instance.PremiumVisibility = true;
                        }
                        catch(Exception e)
                        {
                            return;
                        }
                    }
                }
            }
        }

        #endregion

    }
}
