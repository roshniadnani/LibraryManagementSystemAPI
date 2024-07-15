using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? Author { get; set; }
}
