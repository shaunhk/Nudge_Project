using System;
using System.Collections.Generic;

namespace NVS_Project.Models
{
    public class UserRepository: IUserRepository
    {
        private List<userDetails> users = new List<userDetails>();
        private int _nextId = 1;

        public UserRepository()
        {
            
        }

        public IEnumerable<userDetails> GetAll()
        {
            return users;
        }

        public userDetails Add(userDetails item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            users.Add(item);
            return item;
        }
    }
}