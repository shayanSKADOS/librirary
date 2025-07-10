using System;
using System.Collections.Generic;

namespace Library;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Phone { get; set; }

    public virtual ICollection<Bookloan> Bookloans { get; set; } = new List<Bookloan>();
}
