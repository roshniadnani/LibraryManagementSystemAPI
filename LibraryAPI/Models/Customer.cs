using System;
using System.Collections.Generic;

namespace LibraryAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? ContactNumber { get; set; }
}
