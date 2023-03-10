using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTCGame.DAL;
using MTCGame.Models;

namespace MTCGame.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User LoginUser(Credentials credentials)
        {
            return _userDao.GetUserByCredentials(credentials.Username, credentials.Password) ?? throw new UserNotFoundException();
        }

        public void RegisterUser(Credentials credentials)
        {
            var user = new User(credentials.Username, credentials.Password);
            if (_userDao.InsertUser(user) == false)
            {
                throw new DuplicateUserException();
            }
        }

        public void SetProfileUser(Profiles profiles)
        {
            var user = new User(profiles.Username, profiles.Password, profiles.Nickname, profiles.Image, profiles.Bio);
            if (_userDao.InsertProfiles(user) == false) //das muss iegntlich auf false
            {
                throw new UserNotFoundException();
            }
            /*{
                throw new UserNotFoundException();
            }*/

        }

        public User GetUserByAuthToken(string authToken)
        {
            return _userDao.GetUserByAuthToken(authToken) ?? throw new UserNotFoundException();
        }
    }
}
