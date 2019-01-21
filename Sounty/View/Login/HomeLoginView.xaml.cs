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
    /// Interaction logic for HomeLoginView.xaml
    /// </summary>
    /// 

    public partial class HomeLoginView : UserControl, IHavePassword
    {
        public HomeLoginView()
        {
            InitializeComponent();
            DataContext = HomeLoginViewModel.Instance;
        }
        
        public SecureString PasswordLogin
        {
            get
            {
                return PasswordUserLogin.SecurePassword;
            }
        }

        public SecureString PasswordSignup
        {
            get
            {
                return PasswordUserSignup.SecurePassword;
            }
        }
    }
}
