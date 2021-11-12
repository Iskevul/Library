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

namespace Library
{
    /// <summary>
    /// Interaction logic for Page_Reg.xaml
    /// </summary>
    public partial class Page_Reg : Page
    {
        public Page_Reg()
        {
            InitializeComponent();
        }

        private void Button_AddUser(object sender, RoutedEventArgs e)
        {
            var a = new Reader();
            if (name_txt.Text != "" && name_txt.Text != "" && password_txt.Text != "")
            {
                a.Name = name_txt.Text;
                a.Login = login_txt.Text;
                a.Password = password_txt.Text;
                DB_Connection.Connection.Reader.Add(a);
                DB_Connection.Connection.SaveChanges();
                MessageBox.Show("All OK");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Вы оставили какое-то поле пустым", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
