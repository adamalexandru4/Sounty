using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sounty.Resources
{
    public interface IHavePassword
    {
        System.Security.SecureString PasswordLogin { get; }
        System.Security.SecureString PasswordSignup { get; }
    }

    public interface IHavePasswordChange
    {
        System.Security.SecureString OldPassword { get; }
        System.Security.SecureString NewPassword { get; }
        System.Security.SecureString RepeatNewPassword { get; }
        void ClearText();
    }
}
