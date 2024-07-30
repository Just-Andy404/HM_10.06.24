namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library("BookLib");
            Book book1 = new Book("BookName1");
            Book book2 = new Book("BookName2");
            Book book3 = new Book("BookName3");
            lib.AddBook(book1);
            lib.AddBook(book2);
            Console.WriteLine(lib);
            Console.WriteLine($"Есть ли книга Book2 в библиотеке? {lib.IsBookInLibrary("BookName2")}");
            Console.WriteLine($"Есть ли книга Book3 в библиотеке? {lib.IsBookInLibrary("BookName3")}");
            lib += book3; //Добавим книгу
            Console.WriteLine(lib);
            lib -= "BookName1"; //Удалим книгу
            Console.WriteLine(lib);
            foreach (Book book in lib)
            {
                book.Author = "Unknown";
            }
            Console.WriteLine(lib);
        }
    }
}
