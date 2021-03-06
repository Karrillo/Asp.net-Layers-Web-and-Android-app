﻿using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.ClientAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public class ClientsB : IClientsB
    {
        private ClientAccess clientAccess = new ClientAccess();
        public int CreateCP(int id)
        {
            return clientAccess.CreateCP(id);
        }
        public int Create(Persons input)
        {
            return clientAccess.Create(input);
        }

        public int Delete(int id)
        {
            return clientAccess.Delete(id);
        }

        public int Restore(int id)
        {
            return clientAccess.Restore(id);
        }

        public List<All_Clients> GetAll()
        {
            return clientAccess.GetAll();
        }

        public List<Int64> ClientsAll()
        {
            return clientAccess.ClientsAll();
        }

        public List<All_Clients> GetAllDelete()
        {
            return clientAccess.GetAllDelete();
        }

        public All_Clients GetById(int id)
        {
            return clientAccess.GetById(id);
        }

        public int Update(Persons input, int id)
        {
            return clientAccess.Update(input, id);
        }

        public List<All_Clients> GetByName(String name)
        {
            return clientAccess.GetByName(name);
        }

        public Int64 GetIdClientOwn()
        {
            return clientAccess.GetIdClientOwn();
        }
    }
}
