using Sounty.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sounty
{
    public interface IService
    {
        bool ValidateUsername(string username, bool login, out ICollection<string> validationErrors);
        bool ValidateName(string name, out ICollection<string> validationErrors);
        bool ValidatePhoneNumber(string phoneNumber, out ICollection<string> validationErrors);
        bool ValidateBirthdayDate(DateTime date, out ICollection<string> validationErrors);
    }

    public interface IServicePayment
    {
        bool ValidateCardNumber(string name, out ICollection<string> validationErrors);
        bool ValidateCardHolderName(string name, out ICollection<string> validationErrors);
        bool ValidateExpirationDate(DateTime date, out ICollection<string> validationErrors);
        bool ValidateCVV(string name, out ICollection<string> validationErrors);
    }

    public class ServicePayment : IServicePayment
    {
        public bool ValidateCardNumber(string name, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(name))
            {
                validationErrors.Add("Insert value");
                return false;
            }

            /* Verifying that length of username */
            if (name.Length != 16)
                validationErrors.Add("The card number must have 16 characters.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(name, @"^[0-9]{16}$"))
                validationErrors.Add("The card number must only contain digits");


            return validationErrors.Count == 0;
        }

        public bool ValidateCVV(string name, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(name))
            {
                validationErrors.Add("Insert value");
                return false;
            }

            /* Verifying that length of username */
            if (name.Length != 3)
                validationErrors.Add("The CVV must have 3 characters.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(name, @"^[0-9]{3}$"))
                validationErrors.Add("The CVV must only contain digits");



            return validationErrors.Count == 0;
        }

        public bool ValidateCardHolderName(string name, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(name))
            {
                validationErrors.Add("Insert value");
                return false;
            }

            /* Verifying that length of username */
            if (name.Length > 25 || name.Length < 4)
                validationErrors.Add("The name must be between 4 and 25 characters long.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(name, @"^[a-z A-Z]+$"))
                validationErrors.Add("The name must only contain letters");

            return validationErrors.Count == 0;
        }

        public bool ValidateExpirationDate(DateTime date, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (date.Year <= 2019)
                validationErrors.Add("Select future year");

            return validationErrors.Count == 0;
        }
    }

    public class Service : IService
    {
        public bool ValidateUsername(string username, bool login,out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(username))
            {
                validationErrors.Add("Insert username");
                return false;
            }

            if (login == false)
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var alreadyElem = context.UserSounties.Where(t => t.userName == username).ToList();
                    if (alreadyElem.Count > 0)
                    {
                        validationErrors.Add("The username already exists");
                    }
                }
            }

            /* Verifying that length of username */
            if (username.Length > 25 || username.Length < 4)
            validationErrors.Add("The username must be between 4 and 25 characters long.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+([_.-]?[a-zA-Z0-9])*$"))
                validationErrors.Add("The username must only contain letters, digits, '-' and '_'");

            return validationErrors.Count == 0;
        }

        public bool ValidateName(string name, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(name))
            {
                validationErrors.Add("Insert value");
                return false;
            }

            /* Verifying that length of username */
            if (name.Length > 25 || name.Length < 4)
                validationErrors.Add("The name must be between 4 and 25 characters long.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                validationErrors.Add("The name must only contain letters");

            return validationErrors.Count == 0;
        }

        public bool ValidatePhoneNumber(string phoneNumber, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (String.IsNullOrEmpty(phoneNumber))
            {
                validationErrors.Add("Insert value");
                return false;
            }

            /* Verifying that length of username */
            if (phoneNumber.Length != 10)
                validationErrors.Add("The phone number doesn't have correct length.");

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(phoneNumber, @"^07[0-9]{8}$"))
                validationErrors.Add("The phone number has incorrect format 07..");

            return validationErrors.Count == 0;
        }

        public bool ValidateBirthdayDate(DateTime date, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (date.Year > 2001)
                validationErrors.Add("You are too young");

            return validationErrors.Count == 0;
        }
    }
}
