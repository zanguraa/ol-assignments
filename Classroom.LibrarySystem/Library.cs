namespace LibrarySystem
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public bool RemoveBook(string isbn)
        {
            var bookToRemove = books.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                return true;
            }
            return false;
        }
        public List<Book> ListBooks()
        {
            return books;
        }
    }
}