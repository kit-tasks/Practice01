using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities Entities;

        public static users auth { get; set; }

        public static string[] roles = { "Пользователь", "Менеджер", "Администратор" };
        public static string[] stats = { "забронирован", "оплачен частично", "оплачен полностью" };
    }
}
