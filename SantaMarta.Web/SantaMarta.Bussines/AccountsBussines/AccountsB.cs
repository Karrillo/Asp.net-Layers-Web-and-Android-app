﻿using SantaMarta.Data.Models.Accounts;
using SantaMarta.DataAccess.AccountAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Bussines.AccountsBussines
{
    public class AccountsB : IAccountsB
    {
        private AccountAccess accountAccess = new AccountAccess();

        public bool Create(Accounts input)
        {
            return accountAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return accountAccess.Delete(id);
        }

        public List<Accounts> GetAll()
        {
            return accountAccess.GetAll();
        }

        public Accounts GetById(int id)
        {
            return accountAccess.GetById(id);
        }

        public bool Update(Accounts input)
        {
            return accountAccess.Update(input);
        }
    }
}