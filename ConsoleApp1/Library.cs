using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    internal class Library : IEnumerable<Book>
    {
        public string LibraryName { get; set; }
        public string Address { get; set; }
        public List<Book> _books;
        
        public Library(string name)
        {
            _books = new List<Book>();
            LibraryName = name;
        }
        
        public void AddBook(Book book)
        {
            bool isIn = false;
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Name == book.Name)
                {
                    isIn = true;
                    break;
                }
            }
            if (!isIn)
            {
                _books.Add(book);
            }
        }

        public static Library operator +(Library library, Book book)
        {
            if (!library.IsBookInLibrary(book.Name))
            {
                library.AddBook(book);
            }
            return library;
        }

        public static Library operator -(Library library, string bookName)
        {
            library._books.RemoveAll(book => book.Name == bookName);
            return library;
        }

        public bool IsBookInLibrary(string name)
        {
            foreach (var book in _books)
            {
                if (book.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Books in library:");
            foreach (Book book in _books)
            {
                sb.AppendLine(book.ToString());
            }
            sb.AppendLine("end!");
            return sb.ToString();
        }
    }
}
