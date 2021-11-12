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
    /// Interaction logic for Page_Employee_AddBook.xaml
    /// </summary>
    public partial class Page_Employee_AddBook : Page
    {
        public static ObservableCollection<Author> authors { get; set; }
        public static ObservableCollection<Book> books { get; set; }
        public static ObservableCollection<Department> departments { get; set; }

        public static string selected;

        public Page_Employee_AddBook()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_AddBook(object sender, RoutedEventArgs e)
        {
            authors     = new ObservableCollection<Author>(DB_Connection.Connection.Author.ToList());
            books       = new ObservableCollection<Book>(DB_Connection.Connection.Book.ToList());
            departments = new ObservableCollection<Department>(DB_Connection.Connection.Department.ToList());

            var a = new Book();
            if (bookName.Text != "" && authorName.Text != "" && authorSurname.Text != "" && bookYear.Text != "" && bookDepartment.Text != "")
            {
                a.Name = bookName.Text;
                try
                {
                    a.Author_ID = Convert.ToInt32((from au in authors
                                                   where au.Name == authorName.Text && au.Surname == authorSurname.Text
                                                   select au.Author_ID).First());
                    a.Year = Convert.ToInt32(bookYear.Text);
                    a.Department_ID = Convert.ToInt32((from d in departments
                                                       where d.Name == selected
                                                       select d.Department_ID).First());
                    a.Status = "True";
                    DB_Connection.Connection.Book.Add(a);
                    DB_Connection.Connection.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Этого автора нет в базе данных");
                }
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Вы оставили какое-то поле пустым", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bookDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)(comboBox.SelectedItem);
            selected = selectedItem.Content.ToString();
        }
    }
}
