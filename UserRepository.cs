using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //TODO GetById
        public void Insert(User user)
        {
            _users.Add(user._id, user);
        }
        //TODO Update
        public void Delete(Guid id)
        {
            if (_users.ContainsKey(id)) // Returns true.
            {
                _users.Remove(id); // This is the value at cat.
            }
        }
    }
}
