using System;
using System.Collections.Generic;

namespace Library;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual ICollection<Bookcopy> Bookcopies { get; set; } = new List<Bookcopy>();
}
