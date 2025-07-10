using System;
using System.Collections.Generic;

namespace Library;

public partial class Bookcopy
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Bookloan> Bookloans { get; set; } = new List<Bookloan>();
}
