using System;
using System.CodeDom;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OnlineShop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.Entities = new Entities();
            
        }

        private void ButtonGuest_Click(object sender, RoutedEventArgs e)
        {
            var windowCatalog = new Catalog();
            this.Hide();
            windowCatalog.ShowDialog();
            this.Show();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text;
            //string password = TextBoxPassword.Text;
            string password = PasswordBoxAuthorization.Password;

            try
            {
                var user = this.Login(login, password);

                //Вывод информации о выбранном пользователе
                string message = "Имя: " + user.fullName + " ; Роль: " + App.roles[user.role];
                MessageBox.Show(message, "Пользователь", MessageBoxButton.OK, MessageBoxImage.Information);

                //Переход на следующее окно
                Catalog windowCatalog = new Catalog();
                this.Hide();
                windowCatalog.ShowDialog();
                this.Show();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public users Login(string login, string password)
        {
            //Обработка пустоты
            if (login == "")
            {
                throw new Exception("Логин не введен.");
            }
            if (password == "")
            {
                throw new Exception("Пароль не введен");

            }

            //Поиск логина и пароля в БД

            List<users> users = App.Entities.users.ToList();

            //Авторизация через where
            users user = users.Where(u => u.login.Equals(login)).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Пользователь не найден.");
            }

            //Проверка ввода пароля
            if (!user.password.Equals(password))
            {
                throw new Exception("Введен неверный пароль");
            }

            App.auth = user;

            return user;
        }

        private void CheckBoxPasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBoxPasswordVisibility.IsChecked)
            {
                TextBoxPassword.Visibility = Visibility.Visible;
                PasswordBoxAuthorization.Visibility = Visibility.Hidden;
                TextBoxPassword.Text = PasswordBoxAuthorization.Password;
            }
            else
            {
                TextBoxPassword.Visibility = Visibility.Hidden;
                PasswordBoxAuthorization.Visibility = Visibility.Visible;
                PasswordBoxAuthorization.Password = TextBoxPassword.Text;
            }
        }
    }
}
