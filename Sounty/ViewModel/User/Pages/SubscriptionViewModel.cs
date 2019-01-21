using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{
    public class SubscriptionViewModel : ViewModelBase
    {
        #region Private fields
        

        #endregion

        #region Constructor

        public SubscriptionViewModel()
        {
            Subscriptions = new ObservableCollection<SubscriptionItemViewModel>();
            FillSubscriptionItems();
        }

        #endregion

        #region Subscription items

        private ObservableCollection<SubscriptionItemViewModel> subscriptions;
        public ObservableCollection<SubscriptionItemViewModel> Subscriptions
        {
            get
            {
                if (subscriptions == null)
                    subscriptions = new ObservableCollection<SubscriptionItemViewModel>();

                return subscriptions;
            }

            set
            {
                subscriptions = value;
                OnPropertyChanged("Subscriptions");
            }
        }

        private SubscriptionItemViewModel subscriptionUser;
        public SubscriptionItemViewModel SubscriptionUser
        {
            get => subscriptionUser;
            set
            {
                subscriptionUser = value;
                OnPropertyChanged("SubscriptionUser");
            }
        }

        void FillSubscriptionItems()
        {
            var trialSubscription = new SubscriptionItemViewModel();
            var premiumSubscription = new SubscriptionItemViewModel();

            /* TRIAL */
            trialSubscription.Name = "Basic";
            trialSubscription.Price = "Free";
            trialSubscription.Feature1 = "Free music";
            trialSubscription.Feature2 = "30 seconds/song";
            trialSubscription.Feature3 = "List of friends";
            trialSubscription.Image = @"/Resources/Images/TrialSubscription.png";

            /* PREMIUM */
            premiumSubscription.Name = "Premium";
            premiumSubscription.Price = @"9.99$";
            premiumSubscription.Feature1 = "Millions of songs";
            premiumSubscription.Feature2 = "No advertisment";
            premiumSubscription.Feature3 = "Listen on any devices";
            premiumSubscription.Image = @"/Resources/Images/FullSubscription.png";

            Subscriptions.Add(trialSubscription);
            Subscriptions.Add(premiumSubscription);

            SubscriptionUser = premiumSubscription;
        }

        #endregion

        #region Commands

       

        #endregion
    }
}
