using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MTCGame.Models;

namespace MTCGame.BLL
{
    internal interface IUserManager
    {
        User LoginUser(Credentials credentials);
        void RegisterUser(Credentials credentials);
        User GetUserByAuthToken(string authToken);
    }
}
