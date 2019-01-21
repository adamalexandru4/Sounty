using Sounty.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sounty.ViewModel
{

    public class PaySubscriptionDialogViewModel : ViewModelBase, IDialogRequestClose
    {
        #region IDialog interface

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        #endregion

        #region Private fields

        private string newCreditCardNumber;
        private string newCardHolderName;
        private string newCVV;
        private DateTime newExpirationDate;

        private readonly IServicePayment service;

        #endregion

        #region Constructor

        public PaySubscriptionDialogViewModel()
        {
            PaymentMethods = new ObservableCollection<string>();

            PaymentMethods.Add("Master card");
            PaymentMethods.Add("VISA");
            PaymentMethods.Add("PayPal");
            PaymentMethods.Add("Maestro");

            SelectedMethod = PaymentMethods[1];
            LoadingPayVisibility = false;
            ExpirationDate = DateTime.Today;

            if (service == null)
                service = new ServicePayment();
        }

        #endregion

        #region Commands

        private RelayCommand cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new RelayCommand(t => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));

                return cancelCommand;
            }
        }

        #endregion

        #region Bindings

        private string selectedMethod;
        public string SelectedMethod
        {
            get => selectedMethod;
            set
            {
                selectedMethod = value;
                OnPropertyChanged("SelectedMethod");
            }
        }

        private ObservableCollection<string> paymentMethods = new ObservableCollection<string>();
        public ObservableCollection<string> PaymentMethods
        {
            get => paymentMethods;
            set
            {
                paymentMethods = value;
                OnPropertyChanged("PaymentMethods");
            }
        }

        private bool loadingPayVisibility;
        public bool LoadingPayVisibility
        {
            get => loadingPayVisibility;
            set
            {
                loadingPayVisibility = value;
                OnPropertyChanged("LoadingPayVisibility");
            }
        }

        public string CreditCardNumber
        {
            get => newCreditCardNumber;
            set
            {
                newCreditCardNumber = value;
                OnPropertyChanged("CreditCardNumber");
            }
        }

        public string CardHolderName
        {
            get => newCardHolderName;
            set
            {
                newCardHolderName = value;
                OnPropertyChanged("CardHolderName");
            }
        }

        public string CVV
        {
            get => newCVV;
            set
            {
                newCVV = value;
                OnPropertyChanged("CVV");
            }
        }

        public DateTime ExpirationDate
        {
            get => newExpirationDate;
            set
            {
                newExpirationDate = value;
                OnPropertyChanged("ExpirationDate");
            }
        }

        #endregion

        #region Commands

        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(t => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));

                return closeCommand;
            }
        }

        private RelayCommand payCommand;
        public ICommand PayCommand
        {
            get
            {
                if (payCommand == null)
                    payCommand = new RelayCommand(t => Pay());

                return payCommand;
            }
        }

        async void Pay()
        {
            LoadingPayVisibility = true;
            Validate(newCreditCardNumber, "CreditCardNumber");
            Validate(newCardHolderName, "CardHolderName");
            Validate(newCVV, "CVV");
            Validate(newExpirationDate, "ExpirationDate");
            await Task.Delay(1000);

            LoadingPayVisibility = false;
            if (invalidCreditCardNumber == true ||
                invalidCardholderName == true ||
                invalidExpirationDate == true ||
                invalidCVV == true)
            {

                invalidCreditCardNumber = false;
                invalidCardholderName = false;
                invalidExpirationDate = false;
                invalidCVV = false;
                _validationErrors.Clear();
                return;
            }

            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        #endregion


        #region Validation

        public bool invalidCreditCardNumber = false;
        public bool invalidCardholderName = false;
        public bool invalidExpirationDate = false;
        public bool invalidCVV = false;

        public async void Validate(object name, string propertyKey)
        {
            ICollection<string> validationErrors = null;
            /* Call service asynchronously */
            bool isValid = await Task<bool>.Run(() =>
            {
                switch (propertyKey)
                {
                    case "CreditCardNumber":
                        return service.ValidateCardNumber(name as string, out validationErrors);
                    case "CardHolderName":
                        return service.ValidateCardHolderName(name as string, out validationErrors);
                    case "CVV":
                        return service.ValidateCVV(name as string, out validationErrors);
                    case "ExpirationDate":
                        return service.ValidateExpirationDate((DateTime)name, out validationErrors);
                }
                return false;
            })
            .ConfigureAwait(false);

            if (!isValid)
            {
                switch (propertyKey)
                {
                    case "CreditCardNumber":
                        invalidCreditCardNumber = true;
                        break;
                    case "CardHolderName":
                        invalidCardholderName = true;
                        break;
                    case "CVV":
                        invalidCVV = true;
                        break;
                    case "ExpirationDate":
                        invalidExpirationDate = true;
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
