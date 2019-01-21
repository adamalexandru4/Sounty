using Sounty.Resources;
using Sounty.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sounty.View
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : UserControl, IHavePasswordChange
    {
        public ChangePasswordView()
        {
            InitializeComponent();
            DataContext = ChangePasswordViewModel.Instance;
        }

        public SecureString OldPassword
        {
            get
            {
                return OldPasswordView.SecurePassword;
            }
        }

        public SecureString NewPassword
        {
            get
            {
                return NewPasswordView.SecurePassword;
            }
        }

        public SecureString RepeatNewPassword
        {
            get
            {
                return RepeatNewPasswordView.SecurePassword;
            }
        }

        public void ClearText()
        {
            OldPassword.Clear();
            NewPassword.Clear();
            RepeatNewPassword.Clear();
        }

    }
}
