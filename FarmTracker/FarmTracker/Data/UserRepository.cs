using System;
using System.Collections.Generic;
using System.Text;
using FarmTracker.Model;
using SQLite;

namespace FarmTracker.Data
{
    class UserRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteConnection con;

        public UserRepository(string dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
        }
        public User GetUserByEmailOrUsername(string key)
        {
            try
            {
                return con.Table<User>().Where(x => x.Email == key || x.Username == key)
                                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return null;
        }
        public User GetUserById(Guid guid)
        {
            try
            {
                return con.Table<User>().Where(x => x.Id.Equals(guid))
                                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return null;
        }
        public int InsertUser(User user)
        {
            int result = 0;
            try
            {
                if (user == null)
                    throw new Exception("User can not be null!");
                if (string.IsNullOrEmpty(user.Email))
                    throw new Exception("Email is required");
                if (string.IsNullOrEmpty(user.Password))
                    throw new Exception("Password is required");
                if (string.IsNullOrEmpty(user.Username))
                    throw new Exception("Username is required");
                if (string.IsNullOrEmpty(user.FullName))
                    throw new Exception("FullName is required");
                
                user.Id = Guid.NewGuid();
                result = con.Insert(user);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, user.Email);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", user.Email, ex.Message);
            }

            return result;
        }
    }
}
