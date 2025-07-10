namespace Library;

public class AdminService
{

    public void CreateAdminIfNotExists()
    {
        LibraryContext dbContext = new LibraryContext();
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
}
