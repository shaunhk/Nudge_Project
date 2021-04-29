

using System;
using System.Collections.Generic;

namespace groupbackend.Models


{
    public interface IUserRepository
    {
        IEnumerable<userDetails> GetAll();
        
        userDetails Add(userDetails user);
    }
}