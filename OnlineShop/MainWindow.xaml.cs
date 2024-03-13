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
            StringBuilder sb = new StringBuilder();

            //Обработка пустоты
            if (login == "")
            {
                sb.Append("Логин не введен.\n");
            }
            if (password == "")
            {
                sb.Append("Пароль не введен.\n");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Поиск логина и пароля в БД
            
            List<users> users = App.Entities.users.ToList();

            //Авторизация через where
            users user = users.Where(u => u.login.Equals(login)).FirstOrDefault();
            if (user != null)
            {
                //Проверка ввода пароля
                if (user.password.Equals(password))
                {
                    App.auth = user;

                    //Вывод информации о выбранном пользователе
                    sb.Append("Имя: " + user.fullName + " ; Роль: " + App.roles[user.role]);
                    MessageBox.Show(sb.ToString(), "Пользователь", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Переход на следующее окно
                    Catalog windowCatalog = new Catalog();
                    this.Hide();
                    windowCatalog.ShowDialog();
                    this.Show();

                    return;
                }
                else
                {
                    sb.Append("Введен неверный пароль");
                }
            }
            else
            {
                sb.Append("Пользователь не найден.");
            }
            MessageBox.Show(sb.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
