using Microsoft.EntityFrameworkCore;

namespace Library;

public static class BookService
{
    public static void AddBookCopiesForABook(int bookId, int count)
    {
        var dbContext = new LibraryContext();
        for (int i = 0; i < count; i++)
        {
            var bookCopy = new Bookcopy()
            {
                BookId = bookId,
            };
            dbContext.Bookcopies.Add(bookCopy);
        }
        dbContext.SaveChanges();
    }

    public static void CreateBook(string title, string category, string author, int count)
    {
        var dbContext = new LibraryContext();
        var book = new Book()
        {
            Author = author,
            Title = title,
            Category = category
        };
        dbContext.Books.Add(book);
        dbContext.SaveChanges();

        AddBookCopiesForABook(book.Id, count);
    }
}
