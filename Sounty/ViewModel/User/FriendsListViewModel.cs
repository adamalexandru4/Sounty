using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.ViewModel
{
    public class FriendListItem : ViewModelBase
    {

        private string  name;
        public  bool    online;
        private string  coverImage;
        
        private DateTime lastLoginTime;
        private string lastLogin;

        #region Constructor

        public FriendListItem()
        {

        }

        #endregion

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string CoverImage
        {
            get
            {
                if (coverImage == string.Empty)
                    return @"/Resources/Images/NoProfileImage.png";
                return coverImage;
            }
            set
            {
                coverImage = value;
                OnPropertyChanged("CoverImage");
            }
        }

        public string LastLogin
        {
            get
            {
                if (lastLogin == string.Empty)
                    return "Never been online";

                return lastLogin;
            }
            set
            {

                lastLogin = value;
                OnPropertyChanged("LastLogin");
            }
        }

        public bool IsOnlineVisibility
        {
            get
            {
                return (online == true) ? true : false;
            }
            set
            {
                online = value;
                OnPropertyChanged("IsOnlineVisibility");
            }
        }

        public bool IsOfflineVisibility
        {
            get
            {
                return (online == true) ? false : true;
            }
            set
            {
                online = value;
                OnPropertyChanged("IsOfflineVisibility");
            }
        }
    }
}
