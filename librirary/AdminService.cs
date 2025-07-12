using Microsoft.EntityFrameworkCore;

namespace Library;

public static class AdminService
{
    public static Admin? Login(string username, string password)
    {
        var dbContext = new LibraryContext();
        var hashedPassword = Hashing.QuickHash(password);
        return dbContext.Admins.SingleOrDefault(admin => admin.Username == username && admin.Password == hashedPassword);
    }

    public static void CreateAdminIfNotExists()
    {
        var dbContext = new LibraryContext();
        if (!dbContext.Admins.Any(admin => admin.Username == "admin"))
        {
            var hashedPassword = Hashing.QuickHash("123");
            var newAdmin = new Admin() {
                Username = "admin",
                Password = hashedPassword,
            };
            dbContext.Admins.Add(newAdmin);
            dbContext.SaveChanges();
        }
    }
    public static void CreateANewAdmin(string username, string password)
    {
        var hashedPassword = Hashing.QuickHash(password);
        var dbContext = new LibraryContext();
        var newAdmin = new Admin()
        {
            Username = username,
            Password = hashedPassword,
        };
        dbContext.Admins.Add(newAdmin);
    }
}
