using System;
using System.Collections.Generic;

namespace TestTask.db;

public partial class Client
{
    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string AccountNumber { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Inn { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Responsible { get; set; } = null!;
}
