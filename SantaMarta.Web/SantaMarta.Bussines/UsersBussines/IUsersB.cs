﻿using SantaMarta.Data.Models.Users;
using System.Collections.Generic;

namespace SantaMarta.Bussines.UsersBussines
{
    public interface IUsersB
    {
        Users Check(string nickname, string password);
        bool Create(Users input);
        bool Update(Users input);
        bool Delete(int id);
        Users GetById(int id);
        List<Users> GetAll();
    }
}