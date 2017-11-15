﻿using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.UserAccess
{
    public class UserAccess
    {
        private ContextDb db;

        public UserAccess()
        {
            db = new ContextDb();
        }

        public Users Check(string nickname, string password)
        {
            Users user = new Users();
            try
            {
                user = db.Check_Users(nickname, password);
                if (user != null)
                {
                    user = Decrypt(user);
                }
                else
                {
                    user = new Users();
                }
                user.ConfirmStatus = 200;
                return user;
            }
            catch (Exception)
            {
                user.ConfirmStatus = 500;
                return user;
            }
        }

        public List<Users> GetAll()
        {
            List<Users> users = new List<Users>();

            try
            {
                users = db.List_Users().ToList();
                return users;
            }
            catch (Exception)
            {
                return users;
            }
        }

        public List<Users> GetAllDelete()
        {
            List<Users> users = new List<Users>();

            try
            {
                users = db.List_Users_Deleted().ToList();
                return users;
            }
            catch (Exception)
            {
                return users;
            }
        }

        public Users GetById(Int64 id)
        {
            Users user = new Users();

            try
            {
                user = Decrypt(db.View_Users(id));
                return user;
            }
            catch (Exception)
            {
                return user;
            }
        }

        public int Update(Users user)
        {
            try
            {
                String nickName = db.Check_Nickname(user.Nickname);

                if (nickName == null || nickName == GetById(user.IDUser).Nickname)
                {
                    db.Update_User(Encrypt(user));
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {

                return 500;
            }
        }

        public int Create(Users user)
        {
            try
            {
                if (db.Check_Nickname(user.Nickname) == null)
                {
                    db.Insert_User(Encrypt(user));
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Delete(int id)
        {
            try
            {
                db.Delete_User(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Restore(int id)
        {
            try
            {
                db.Restore_User(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        private Users Encrypt(Users user)
        {
            string pass = user.Password;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(pass);
            user.Password = Convert.ToBase64String(encrypted);
            return user;
        }

        private Users Decrypt(Users user)
        {
            string pass = user.Password;
            byte[] decrypted = Convert.FromBase64String(pass);
            user.Password = System.Text.Encoding.Unicode.GetString(decrypted);
            return user;
        }
    }
}
