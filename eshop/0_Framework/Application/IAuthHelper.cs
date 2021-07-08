using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void SingIn(AuthViewModel account);
        void SingOut();
        bool IsAuthenticated();

    }
}
