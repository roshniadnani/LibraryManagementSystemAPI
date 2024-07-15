using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class BorrowedBook
{
    public int? BookId { get; set; }

    public string? BookName { get; set; }

    public int? IssuerId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Customer? Issuer { get; set; }
}
