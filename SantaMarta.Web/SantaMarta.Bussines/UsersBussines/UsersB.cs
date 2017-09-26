﻿using System.Collections.Generic;
using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.UserAccess;

namespace SantaMarta.Bussines.UsersBussines
{
    public class UsersB : IUsersB
    {

        private UserAccess userAccess = new UserAccess();

        public Users Check(string nickname, string password)
        {
            return userAccess.Check(nickname, password);
        }

        public int Create(Users input)
        {
            return userAccess.Create(input);
        }

        public int Delete(int id)
        {
            return userAccess.Delete(id);
        }

        public List<Users> GetAll()
        {
            return userAccess.GetAll();
        }

        public Users GetById(int id)
        {
            return userAccess.GetById(id);
        }

        public int Update(Users input)
        {
            return userAccess.Update(input);
        }
    }
}
