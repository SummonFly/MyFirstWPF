using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFirstWPF
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }
    }

    public class DataBaseManager
    {
        public List<User> Users;

        private static DataBaseManager _dataBase;
        private string _connectionString = "Data Source=UserDataBase.db";
        private SQLiteConnection _connection;

        public static DataBaseManager GetManager()
        {
            if (_dataBase == null)
            {
                _dataBase = new DataBaseManager();
            }
            _dataBase.SaveDataBase();
            return _dataBase;
        }

        private void LoadDataBase()
        {
            _connection.Open();

            SQLiteCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT * FROM Users";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Users.Add(new User(reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }
            _connection.Close();
        }

        private void SaveDataBase()
        {
            Users.Add(new User("Login", "Password", "Email"));

            Users.Add(new User("Login", "Password", "Email"));
            Users.Add(new User("Login", "Password", "Email"));

            _connection.Open();

            SQLiteCommand command = new SQLiteCommand();
            command.Connection = _connection;


            for(int i = 0; i < Users.Count; i++)
            {
                //command.CommandText = $"INSERT INTO Users (Login, Password, Email) VALUES('{Users[i].Login}', '{Users[i].Password}', '{Users[i].Email}')";
                command.CommandText = $"INSERT INTO Users (Login, Password, Email) VALUES('Login', 'Password', 'Email')";
                MessageBox.Show("Успешно " + command.ExecuteNonQuery().ToString ());
            }

            _connection.Close();
            _connection.Dispose();
        }

        private DataBaseManager()
        {
            _connection = new SQLiteConnection(_connectionString);
            Users = new List<User>();
        }
    }

    
}
