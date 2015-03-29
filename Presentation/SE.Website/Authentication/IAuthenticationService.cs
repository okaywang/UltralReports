using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Filters
{
    public interface IAuthenticationService
    {
        void SignIn(string userId, bool createPersistentCookie);
        void SignOut();
    }
}