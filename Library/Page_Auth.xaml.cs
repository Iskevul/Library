using System;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Page_Auth.xaml
    /// </summary>
    public partial class Page_Auth : Page
    {
        public static User CurrentUser = new User();
        public static ObservableCollection<Reader> readers { get; set; }
        public static ObservableCollection<Employee> staff { get; set; }
        public Page_Auth()
        {
            InitializeComponent();
        }

        private void Button_SignIn(object sender, RoutedEventArgs e)
        {
            readers = new ObservableCollection<Reader>(DB_Connection.Connection.Reader.ToList());
            var reader = readers.Where(a => a.Login == txt_login.Text && a.Password == txt_password.Text).FirstOrDefault();
            if (reader != null && reader.Login != "" && reader.Password != "")
            {
                MessageBox.Show("Вы вошли как читатель " + reader.Name);
                CurrentUser.ID       = reader.Reader_ID;
                CurrentUser.Name     = reader.Name;
                CurrentUser.Login    = reader.Login;
                CurrentUser.Password = reader.Password;
                CurrentUser.Status   = "Reader";
                NavigationService.Navigate(new Page_Reader());
            }
            else
            {
                staff = new ObservableCollection<Employee>(DB_Connection.Connection.Employee.ToList());
                var worker = staff.Where(a => a.Login == txt_login.Text && a.Password == txt_password.Text).FirstOrDefault();
                if (worker != null && worker.Login != "" && worker.Password != "")
                {
                    MessageBox.Show("Вы вошли как сотрудник " + worker.Name);
                    CurrentUser.ID       = worker.Employee_ID;
                    CurrentUser.Name     = worker.Name;
                    CurrentUser.Login    = worker.Login;
                    CurrentUser.Password = worker.Password;
                    CurrentUser.Status   = "Employee";
                    NavigationService.Navigate(new Page_Employee());
                }
            }
        }

        private void Button_SignUp(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Reg());
        }        
    }

    public class User
    {
        public int ID;
        public string Name;
        public string Login;
        public string Password;
        public string Status;
    }
}
