﻿using System.Collections.Generic;
using SantaMarta.Data.Models.Persons;
using SantaMarta.DataAccess.Entity;
using System;

namespace SantaMarta.DataAccess.PersonAccess
{
    public class PersonAccess
    {
        private ContextDb db;

        public PersonAccess()
        {
            db = new ContextDb();
        }

        public List<Persons> GetAll()
        {
            return null;
        }

        public String CheckIdentification(string identification)
        {
            return null;
        }

        public String CheckCode(string code)
        {
            return null;
        }

        public Persons GetById(int id)
        {
            return null;
        }

        public bool Update(Persons user)
        {
            return true;
        }

        public bool Create(Persons user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
