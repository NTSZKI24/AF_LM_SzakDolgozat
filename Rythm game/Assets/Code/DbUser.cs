using Database_LM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Database_LM
{
    //----------Models------------------
    public class UserPostModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
    }

    public class UserGetModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
    class DbUser
    {
        private MySqlConnection _connection { get; set; } 
        public DbUser(MySqlConnection connection)
        {
            _connection = connection;
        }

        //-----------PareseObj----------------
        public UserGetModel Parse(DbDataReader reader)
        {
            UserGetModel user = null;
            if (reader.Read())
            {
                user = new UserGetModel()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2),
                    Score = reader.GetInt32(5)
                };
            }
            reader.Close();
            return user;
        }

        public User ParseForAuthenticate(DbDataReader reader)
        {
            User user = null;
            if (reader.Read())
            {
                user = new User()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2),
                    Password_Hash = reader.GetString(3),
                    Password_Salt = reader.GetString(4),
                    Score = reader.GetInt32(5)
                };
            }
            reader.Close();
            return user;
        }
        //-------------Methods-----------------
        public string Post(UserPostModel obj)
        {
            try
            {
                User Conflict = null;
                var cmd1 = _connection.CreateCommand();
                cmd1.CommandText = $"SELECT * FROM user where Email='{obj.Email}'";
                Conflict=ParseForAuthenticate(cmd1.ExecuteReader());
                if (Conflict == null)
                {
                    PasswordHasher.CreatePasswordHash(obj.Password, out string hash, out string salt);

                    var cmd = _connection.CreateCommand();
                    cmd.CommandText = $"INSERT INTO `user`(`Email`, `Name`, `Password_Hash`, `Password_Salt`, `Score`) VALUES ('{obj.Email}','{obj.Name}','{hash}','{salt}',{obj.Score})";
                    var row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("Data saved!");
                        return obj.Name;
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        return "Error";
                    }
                }
                if (Conflict != null)
                {
                    return "E-Mail cím már létezik.";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
            return "Remélem nem ezt küldi vissza :D";
        }

        public void Delete(int id)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM `user` WHERE Id={id}";
            var row = cmd.ExecuteNonQuery();
            if (row != 0)
            {
                Console.WriteLine("Data removed!");
            }
            else Console.WriteLine("Error!");
        }

        public List<UserGetModel> Get()
        {
            var UserList = new List<UserGetModel>();
            var cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM `user`";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserList.Add(new UserGetModel()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2),
                    Score = reader.GetInt32(5)
                });
            }
            reader.Close();
            return UserList;
        }

        public UserGetModel Get1(int id)
        {
            try
            {
                var UserList = new List<UserGetModel>();
                var cmd = _connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM `user` where Id={id}";
                var result = Parse(cmd.ExecuteReader());
                cmd.ExecuteReader().Close();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Update(int id, UserPostModel obj)
        {
            PasswordHasher.CreatePasswordHash(obj.Password, out string hash, out string salt);
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"UPDATE `user` SET `Email`='{obj.Email}',`Name`='{obj.Name}',`Password_Hash`='{hash}',`Password_Salt`='{salt}',`Score`='{obj.Score}' WHERE Id='{id}'";
            var row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                Console.WriteLine("Data updated!");
            }
            else Console.WriteLine("Error!");
        }

        public bool Authenticate(string email, string password)
        {
            var UserList = new List<User>();
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM `user`";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserList.Add(new User()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    Name = reader.GetString(2),
                    Password_Hash = reader.GetString(3),
                    Password_Salt = reader.GetString(4),
                    Score = reader.GetInt32(5)
                });
            }
            reader.Close();

            var result = UserList.Where(x => x.Email==email).FirstOrDefault();
            var valid =false;
            if(result != null)
            {

                 valid = PasswordHasher.VerifyPasswordHash
                        (password, result.Password_Hash, result.Password_Salt);
            }
            else Console.WriteLine("Nem létező email!");

            if (valid) 
            { 
                return true;
            }
            else
            {
                Console.WriteLine("Rossz jelszó!");
                return false;
            }
        }
    }
}
