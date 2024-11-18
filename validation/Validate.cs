using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Desktop.validation
{
    static class Validate
    {

        // Метод для проверки на пустую строку

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidName(this string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 3;
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }


        public static bool IsValidPassword(this string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= 6;
           
        }

        public static string PasswordsMatch(this string password, string password2)
        {
            if (password != password2)
            {
                return "Пароли не совпадают!";
            }
            return string.Empty; // Возвращаем пустую строку, если пароли совпадают
        }

    }
}
