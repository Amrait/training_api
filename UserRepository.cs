using System;
using System.Collections.Generic;
using System.Linq;
using TrainingApi.Entities;

namespace TrainingApi
{
    public class UserRepository
    {
        private static Dictionary<Guid, User> _users = new Dictionary<Guid, User>();
        public List<User> All()
        {
            return _users.Values.ToList();
        }

        public User GetById(Guid id)
        {
            User result = null;
            // Just to throw some logging around.
            if (!_users.TryGetValue(id, out result))
            {
                Console.WriteLine($"WARN: failed to find user with specified id {id.ToString()} in our records!");
            }
            return result;
        }

        public void Insert(User user)
        {
            _users.Add(user._id, user);
        }

        public bool Update(Guid id, string userName, string password)
        {
            if (_users.ContainsKey(id))
            {
                User user = _users[id];
                if (!String.IsNullOrWhiteSpace(userName))
                {
                    user._userName = userName;
                }
                if (!String.IsNullOrWhiteSpace(password))
                {
                    user._password = password;
                }
                _users[id] = user;
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            if (_users.ContainsKey(id)) // Returns true.
            {
                _users.Remove(id); // This is the value at cat.
                return true;
            }
            return false;
        }
    }
}
