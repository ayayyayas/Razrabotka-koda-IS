using Desktop.Repository;
using Desktop.validation;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Log_In.xaml
    /// </summary>
    public partial class Log_In : Window
    {
        public Log_In()
        {
            InitializeComponent();
        }
        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Убираем текст placeholder при фокусе
            if (EmailTextBox.Text == "Введите почту")
            {
                EmailTextBox.Text = "";
            }

            // Делаем вводимый текст черным
            EmailTextBox.Foreground = Brushes.Black;
            EmailTextBox.Opacity = 1.0;
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.Text = "Введите почту";
                EmailTextBox.Foreground = Brushes.Gray;

            }
        }
        private void TextBoxWithPlaceholder_GotFocus(object sender, RoutedEventArgs e)
        {

            // Убираем текст placeholder при фокусе
            if (TextBoxWithPlaceholder.Text == "Введите пароль")
            {
                TextBoxWithPlaceholder.Text = "";
            }

            // Делаем вводимый текст черным
            TextBoxWithPlaceholder.Foreground = Brushes.Black;
            TextBoxWithPlaceholder.Opacity = 1.0;
        }

        private void TextBoxWithPlaceholder_LostFocus(object sender, RoutedEventArgs e)
        {
            // Возвращаем текст placeholder при потере фокуса, если поле пустое
            if (string.IsNullOrWhiteSpace(TextBoxWithPlaceholder.Text))
            {
                TextBoxWithPlaceholder.Text = "Введите пароль";
                TextBoxWithPlaceholder.Foreground = Brushes.Gray;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            WindowManager.SwitchWindow(this, reg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                string email = EmailTextBox.Text.Trim();
                string password = TextBoxWithPlaceholder.Text.Trim();

                bool isEmailValid = email.IsValidEmail();
                bool isPasswordValid = password.IsValidPassword();
              
                string errorMessage = "Ошибка валидации:";
                if (email == "exam@yandex.ru")
                {
                    errorMessage += "\nНедопустимый email.";
                }
                if (!isEmailValid)
                {
                    errorMessage += "\nВведите корректный email.";
                }
                if (password == "Введите пароль")
                {
                    errorMessage += "\nВведите пароль.";
                }
                if (!isPasswordValid)
                    {
                    errorMessage += "\nПароль должен содержать не менее 6 символов.";
                }
                if (isEmailValid && isPasswordValid && email != "exam@yandex.ru" && password != "Введите пароль")
                {
                    var userRep = new UserRepository();
                    var user = userRep.GetUser(EmailTextBox.Text, TextBoxWithPlaceholder.Text);

                    if (user != null)
                        {
                        MessageBox.Show($"Вход выполнен успешно! Добро пожаловать, {user.UserName}!" , "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        Maim_empty main_Empty = new Maim_empty();
                        WindowManager.SwitchWindow(this, main_Empty);
                    }

                else
                    {
                        MessageBox.Show("Неверный email или пароль!");
                    }
                
            }
                else
                {
                    // Выводим сообщение с ошибками, если есть ошибки
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

                

               
                }

        }

    }
        public static class WindowManager
        {

            public static void SwitchWindow(Window currentWindow, Window newWindow)
            {
                newWindow.Show();
                currentWindow.Hide();
            }
        }

