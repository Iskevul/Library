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
    /// Interaction logic for Page_Reader.xaml
    /// </summary>
    public partial class Page_Reader : Page
    {
        
        public Page_Reader()
        {
            InitializeComponent();
            UserName.Text = Page_Auth.CurrentUser.Name;
            
            //var result = new ObservableCollection<CompetVenue>(infoCompet.Join(infoVenue, p => p.ID_venue, g => g.ID_venue, (p, g) => new CompetVenue { Name = p.Name, venue = g.Name, Date_of_the_event = p.Date_of_the_event.ToString(), Street = g.Street, Number_home = g.Number_home.ToString() }).ToList());
        }

        private void Button_MyBooks(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_Reader_MyBooks());
        }

        private void Button_BooksInLibrary(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page_BooksInLibrary());
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Page_Auth.CurrentUser.Name     = "";
            Page_Auth.CurrentUser.Login    = "";
            Page_Auth.CurrentUser.Password = "";
            Page_Auth.CurrentUser.Status   = "";

            

            NavigationService.GoBack();
        }
    }

    public class BookInfo
    {
        public int Book_ID;
        public string Name;
        public string Author;
        public int Year;
        public string Department;
        public string Status;



    }
}
