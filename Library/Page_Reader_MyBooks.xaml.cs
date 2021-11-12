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
    /// Interaction logic for Page_Reader_MyBooks.xaml
    /// </summary>

    public partial class Page_Reader_MyBooks : Page
    {
        public static ObservableCollection<Book> books { get; set; }
        public static ObservableCollection<Author> authors { get; set; }
        public static ObservableCollection<Department> departments { get; set; }
        public static ObservableCollection<Reader> readers { get; set; }
        public static ObservableCollection<Ticket> tickets { get; set; }

        public static MyBook path;

        public static IEnumerable<MyBook> temp { get; set; }

        //public static ObservableCollection<BookTemp> temp { get; set; }

        public Page_Reader_MyBooks()
        {
            InitializeComponent();
            books = new ObservableCollection<Book>(DB_Connection.Connection.Book.ToList());
            readers = new ObservableCollection<Reader>(DB_Connection.Connection.Reader.ToList());
            tickets = new ObservableCollection<Ticket>(DB_Connection.Connection.Ticket.ToList());
            authors = new ObservableCollection<Author>(DB_Connection.Connection.Author.ToList());
            departments = new ObservableCollection<Department>(DB_Connection.Connection.Department.ToList());

            temp = from b in books
                   join t in tickets on b.Book_ID equals t.Book_ID
                   join a in authors on b.Author_ID equals a.Author_ID
                   join d in departments on b.Department_ID equals d.Department_ID
                   where t.Reader_ID == Page_Auth.CurrentUser.ID
                   select new MyBook
                   {
                       Book_ID = b.Book_ID,
                       Name = b.Name,
                       AuthorName = a.Name,
                       AuthorSurname = a.Surname,
                       Year = Convert.ToInt32(b.Year),
                       Department = d.Name

                   };

            List<MyBook> myBooks = new List<MyBook>();
            foreach (var t in temp)
            {
                myBooks.Add(new MyBook(t.Book_ID, t.Name, t.AuthorName, t.AuthorSurname, t.Year, t.Department));
            }

            grid.ItemsSource = myBooks;

            this.DataContext = this;


        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_ReturnBook(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                tickets = new ObservableCollection<Ticket>(DB_Connection.Connection.Ticket.ToList());
                books = new ObservableCollection<Book>(DB_Connection.Connection.Book.ToList());

                var book = books.Where(a => a.Book_ID == path.Book_ID).FirstOrDefault();
                book.Status = "True";

                var ticket = tickets.Where(a => a.Book_ID == path.Book_ID).FirstOrDefault();

                DB_Connection.Connection.Ticket.Remove(ticket);
                DB_Connection.Connection.SaveChanges();
            }
            else
            {
                MessageBox.Show("Вы не выбрали книгу");
            }
        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            path = grid.SelectedItem as MyBook;
        }
    }
}
