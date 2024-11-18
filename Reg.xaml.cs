using Desktop.Repository;
using Desktop.validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Todo.Entities;
using static Desktop.Log_In;


namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        
        public Reg()
        {
            InitializeComponent();
           
        }
        private void NameUser_GotFocus(object sender, RoutedEventArgs e)
        {
            // Убираем текст placeholder при фокусе
            if (NameUser.Text == "Введите имя пользователя")
            {
                NameUser.Text = "";
            }

            // Делаем вводимый текст черным
            NameUser.Foreground = Brushes.Black;
            NameUser.Opacity = 1.0;
        }

        private void NameUser_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(NameUser.Text))
            {
                NameUser.Text = "Введите имя пользователя";
                NameUser.Foreground = Brushes.Gray;

            }
        }
        private void EmailUser_GotFocus(object sender, RoutedEventArgs e)
        {
            // Убираем текст placeholder при фокусе
            if (EmailUser.Text == "exam@yandex.ru")
            {
                EmailUser.Text = "";
            }

            // Делаем вводимый текст черным
            EmailUser.Foreground = Brushes.Black;
            EmailUser.Opacity = 1.0;
        }

        private void EmailUser_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(EmailUser.Text))
            {
                EmailUser.Text = "exam@yandex.ru";
                EmailUser.Foreground = Brushes.Gray;

            }
        }
        private void ParolUser_GotFocus(object sender, RoutedEventArgs e)
        {
            // Убираем текст placeholder при фокусе
            if (ParolUser.Text == "Введите пароль")
            {
                ParolUser.Text = "";
                ParolUser.Foreground = Brushes.Black;
            }
        }

        private void ParolUser_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(ParolUser.Text))
            {
                ParolUser.Text = "Введите пароль";
                ParolUser.Foreground = Brushes.Gray;
            }
        }
        private void Parol2User_GotFocus(object sender, RoutedEventArgs e)
        {
            // Убираем текст placeholder при фокусе
            if (Parol2User.Text == "Повторите пароль")
            {
                Parol2User.Text = "";
            }

            // Делаем вводимый текст черным
            Parol2User.Foreground = Brushes.Black;
            Parol2User.Opacity = 1.0;
        }

        private void Parol2User_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(Parol2User.Text))
            {
                Parol2User.Text = "Повторите пароль";
                Parol2User.Foreground = Brushes.Gray;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Log_In log_In = new Log_In();
            log_In.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string name = NameUser.Text.Trim();
            string email = EmailUser.Text.Trim();
            string password = ParolUser.Text.Trim();
            string password2 = Parol2User.Text.Trim();

            // Проверяем данные с использованием методов расширения
            bool isEmailValid = email.IsValidEmail();
            bool isPasswordValid = password.IsValidPassword();
            bool isNameValid = name.IsValidName();

            // Проверка на стандартный текст для всех полей
            string errorMessage = "Ошибка валидации:";

            // Проверка на стандартный текст в email
            if (email == "exam@yandex.ru" || email == "Введите email")
            {
                errorMessage += "\nНедопустимый email.";
            }

            // Проверка на стандартный текст в пароле
            if (password == "Введите пароль")
            {
                errorMessage += "\nПароль не должен быть пустым";
            }

            // Проверка на стандартный текст в имени пользователя
            if (name == "Введите имя пользователя")
            {
                errorMessage += "\nИмя не должно  быть пустым.";
            }

            // Добавление ошибок валидации
            if (!isEmailValid)
            {
                errorMessage += "\nНеверный email.";
            }

            if (!isPasswordValid)
            {
                errorMessage += "\nПароль должен содержать не менее 6 символов.";
            }

            if (!isNameValid)
            {
                errorMessage += "\nИмя должно содержать не менее 3 знаков.";
            }

            // Проверка на совпадение паролей
            if (password != password2)
            {
                errorMessage += "\nПароли не совпадают!";
            }

            // Проверка всех условий для успешного входа
            if (isEmailValid && isPasswordValid && isNameValid && email != "exam@yandex.ru" && password != "Введите пароль" && name != "Введите имя пользователя" && password == password2)
            {
                var userRepo = new UserRepository();
                bool success = userRepo.RegisterUser(NameUser.Text, EmailUser.Text, ParolUser.Text);
                if (success)
                {
                    MessageBox.Show("Регистрация выполнена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                if (!success)
                {
                    MessageBox.Show("Email уже занят. Пожалуйста, выберите другой.");
                }


                //Maim_empty main_Empty = new Maim_empty();
                //WindowManager.SwitchWindow(this, main_Empty);
            }
            else
            {
                // Выводим сообщение с ошибками, если есть ошибки
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }






        }


    }
}
