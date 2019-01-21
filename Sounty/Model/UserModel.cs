using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.Model
{
    public class UserModel
    {
        #region Private Fields

        private int userId;
        private string userName;
        private string firstName;
        private string lastName;
        private string userAddress;
        private string phoneNumber;
        private DateTime birthdayDate;
        private DateTime lastLogin;
        private bool activeStatus;

        #endregion

        #region Constructor

        public UserModel(DataAccess.UserInfo user)
        {
            this.UserId = user.userInfoId;
            
            // UserName from DB
            using (var context = new DataAccess.SountyDB())
            {
                try
                {
                    var usernameDB = (from userSounty in context.UserSounties
                                    where userSounty.userId == this.UserId
                                    select userSounty.userName).Single();
                    UserName = usernameDB;
                }
                catch (Exception)
                {
                    return;
                }
            };

            this.FirstName = user.firstName;
            this.LastName = user.lastName;
            this.UserAddress = user.userAddress;
            this.PhoneNumber = user.phoneNumber;
            this.BirthdayDate = user.birthDate ?? DateTime.Now;
            this.LastLogin = user.lastLogin ?? DateTime.Now;
            this.ActiveStatus = user.activeStatus ?? true;


        }

        #endregion

        #region Public Fields

        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string UserAddress { get => userAddress; set => userAddress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime BirthdayDate { get => birthdayDate; set => birthdayDate = value; }
        public DateTime LastLogin { get => lastLogin; set => lastLogin = value; }
        public bool ActiveStatus { get => activeStatus; set => activeStatus = value; }

        #endregion
    }
}
