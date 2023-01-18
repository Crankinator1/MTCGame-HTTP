﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTCGame.Models;

namespace MTCGame.DAL
{
    public class InMemoryUserDao : IUserDao
    {
        private readonly List<User> _users = new();

        public User? GetUserByAuthToken(string authToken)
        {
            return _users.SingleOrDefault(u => u.Token == authToken);
        }

        public User? GetUserByCredentials(string username, string password)
        {
            return _users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool InsertUser(User user)
        {
            var inserted = false;

            if (GetUserByUsername(user.Username) == null)
            {
                _users.Add(user);
                inserted = true;
            }

            return inserted;
        }

        private User? GetUserByUsername(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }

        public bool InsertProfiles(User user)
        {
            var inserted = false;

            if (GetUserByUsername(user.Username) == null)
            {
                //_users.Add(user);
                inserted = false;
            }

            return inserted;
            /*var inserted = false;

            if (GetUserByUsername(user.Username) == null) //Keine Ahnung dies ist mal ein Test
            {
                inserted = false;
            }

            return inserted;*/
        }
    }
}
