using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MyBook
    {
        public MyBook(int id, string name, string authorName, string authorSurname, int year, string dep)
        {
            this.Book_ID = id;
            this.Name = name;
            this.AuthorName = authorName;
            this.AuthorSurname = authorSurname;
            this.Year = year;
            this.Department = dep;
        }

        public MyBook()
        {

        }
        public int Book_ID { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }

    }
}
