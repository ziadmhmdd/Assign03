namespace ConsoleApp1
{
    public delegate string BookFunctionPointer(Book b);

    internal class Program
    {
        static void Main()
        {


            #region User Defined Delegate
            List<Book> books = new List<Book> 
            {
               new Book("111", "C# Basics", new string[] {"Ahmed Ali"}, new DateTime(2020, 5, 1), 150),
               new Book("222", "Advanced C#", new string[] {"Sara Mohamed", "Omar Ali"}, new DateTime(2021, 3, 15), 250)
            };

            BookFunctionPointer ptr = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(books, new Func<Book, string>(ptr));

            Console.WriteLine("-----");

            #endregion

            #region Built-in Delegate

            Func<Book, string> builtInPtr = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(books, builtInPtr);

            Console.WriteLine("-----");

            #endregion

            #region Anonymous Method 

            Func<Book, string> anon = delegate (Book b)
            {
                return b.ISBN;
            };
            LibraryEngine.ProcessBooks(books, anon);

            Console.WriteLine("-----");

            #endregion

            #region Lambda Expression

            Func<Book, string> lambda = b => b.PublicationDate.ToShortDateString();
            LibraryEngine.ProcessBooks(books, lambda);

            #endregion




        }
    }
}
