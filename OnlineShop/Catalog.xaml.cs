using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace OnlineShop
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {

        public Catalog()
        {
            InitializeComponent();

            if (App.auth != null)
            {
                tbUserName.Text = "Пользователь: " + App.auth.fullName;
            }
            //Гость
            else
            {
                tbUserName.Text = "Пользователь: Гость";
            }

            List<ItemExtended> listItemsExt = new List<ItemExtended>();
            List<items> listItems = App.Entities.items.ToList();

            foreach (items item in listItems)
            {
                ItemExtended itemExtended = new ItemExtended();
                itemExtended.item = item;
                listItemsExt.Add(itemExtended);
            }

            ListBoxItems.ItemsSource = listItemsExt;
        }
        private void ButtonNavigation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
