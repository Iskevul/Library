using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;
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
    /// Interaction logic for Page_Authors.xaml
    /// </summary>
    public partial class Page_Authors : Page
    {
        public static ObservableCollection<Author> authors { get; set; }
        public Page_Authors()
        {
            InitializeComponent();
            authors = new ObservableCollection<Author>(DB_Connection.Connection.Author.ToList());

            List<MyAuthor> authList = new List<MyAuthor>();
            foreach (var a in authors)
            {
                authList.Add(new MyAuthor(a.Author_ID, a.Name, a.Surname, a.Patronymic, Convert.ToDateTime(a.BirthDate), Convert.ToDateTime(a.DeathDate)));
            }
            grid.ItemsSource = authList;
            this.DataContext = this;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    public class MyAuthor
    {
        public MyAuthor(int id, string name, string surname, string patronymic="", DateTime birthDate=new DateTime(), DateTime deathDate= new DateTime())
        {
            this.Author_ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.BirthDate = birthDate;
            this.DeathDate = deathDate;
        }

        public MyAuthor()
        {

        }

        public int Author_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }

    }
}
