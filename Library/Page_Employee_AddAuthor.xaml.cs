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
    /// Interaction logic for Page_Employee_AddAuthor.xaml
    /// </summary>
    public partial class Page_Employee_AddAuthor : Page
    {
        public static ObservableCollection<Author> authors;
        public static DateTime BD;
        public static DateTime DD;
        public Page_Employee_AddAuthor()
        {
            InitializeComponent();
        }

        private void Button_AddAuthor(object sender, RoutedEventArgs e)
        {
            var author = new Author();
            if (authorName.Text != "" && authorSurname.Text != "")
            {
                author.Name = authorName.Text;
                author.Surname = authorSurname.Text;
                if (authorPatronymic.Text != "")
                {
                    author.Patronymic = authorPatronymic.Text;
                }
                if (BD != null)
                {
                    author.BirthDate = BD;
                }
                if (DD != null)
                {
                    author.DeathDate = DD;
                }
                DB_Connection.Connection.Author.Add(author);
                DB_Connection.Connection.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Вы не вписали имя или фамилию");
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BD = birthDate.SelectedDate.Value;
        }

        private void deathDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DD = deathDate.SelectedDate.Value;
        }
    }
}
