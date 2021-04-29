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
            Add(new userDetails { firstName= "first1", lastName="last1", gender= "female"});
            Add(new userDetails { firstName= "first2", lastName="last2", gender="female"});
            Add(new userDetails { firstName= "first3", lastName="last3", gender="female"});
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
            item.studentID = _nextId++;
            users.Add(item);
            return item;
        }
    }
}