

using System;
using System.Collections.Generic;

namespace NVS_Project.Models


{
    public interface IUserRepository
    {
        IEnumerable<userDetails> GetAll();
        
        userDetails Add(userDetails user);
    }
}