using Microsoft.EntityFrameworkCore;

namespace Library;

public static class MemberService
{
    public static Member? Login(string username, string password)
    {
        var dbContext = new LibraryContext();
        var hashedPassword = Hashing.QuickHash(password);
        return dbContext.Members.SingleOrDefault(member => member.Username == username && member.Password == hashedPassword);
    }

    public static IQueryable<Bookloan> GetLoanedBooksOfMember(int memberId)
    {
        return new LibraryContext()
            .Bookloans
            .Include(l => l.BookCopy)
            .Include(l => l.BookCopy.Book)
            .Where(loaned => loaned.MembrId == memberId)
            .Where(loaned => !loaned.ReturnDate.HasValue);
    }
}
