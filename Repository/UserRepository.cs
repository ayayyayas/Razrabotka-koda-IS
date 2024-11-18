using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Desktop.Repository
{
   public class UserRepository
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
        new UserModel {UserEmail = "anastsiavolkova@gmail.com",  UserName = "anastasia", Password = "qwerty"}
        };

       
        public UserModel? GetUser(string email, string password)
        {
            return _users.FirstOrDefault( user => user.UserEmail == email  && user.Password == password);
        }

       
        public bool RegisterUser(string username, string useremail, string password)
        {

            if (_users.Exists(u => u.UserEmail.Equals(useremail, StringComparison.OrdinalIgnoreCase)) )
            {
                return false; 
            }

            
            _users.Add( new UserModel { UserName = username, UserEmail = useremail, Password = password });
            
            return true; 
        }


        // Метод для авторизации пользователя

        public UserModel? AuthenticateUser(string useremail, string username, string password)
        {
            return _users.FirstOrDefault(user =>
                user.UserEmail == useremail && user.UserName == username && user.Password == password);
        }


        // Метод для получения всех зарегистрированных пользователей (для проверки)

    }
}
