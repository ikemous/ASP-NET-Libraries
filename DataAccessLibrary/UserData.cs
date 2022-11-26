using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<UserModel>> GetUsers()
        {
            string sql = "SELECT * FROM Users";
            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }
        public Task InsertUser(UserModel user)
        {
            string sql = @"INSERT INTO Users (UserEmail, UserPassword)
                           VALUES (@UserEmail, @UserPassword);";
            return _db.SaveData(sql, user);
        }
    }
}
