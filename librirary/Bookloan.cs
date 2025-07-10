using System;
using System.Collections.Generic;

namespace Library;

public partial class Bookloan
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }

    public int MembrId { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Bookcopy BookCopy { get; set; } = null!;

    public virtual Member Membr { get; set; } = null!;
}
