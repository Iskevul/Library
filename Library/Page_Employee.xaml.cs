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
    /// Interaction logic for Page_Employee.xaml
    /// </summary>
    public partial class Page_Employee : Page
    {
        public Page_Employee()
        {
            InitializeComponent();
            UserName.Text = Page_Auth.CurrentUser.Name;
        }

        private void Button_AddBook(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Employee_AddBook());
        }

        private void Button_BooksInLibrary(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_BooksInLibrary());
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_AddAuthor(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Employee_AddAuthor());
        }

        private void Button_Authors(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Authors());
        }
    }
}
