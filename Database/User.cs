using System;
using System.Collections.Generic;

namespace TestTask.db;

public partial class User
{
    public Guid Uui { get; set; } = Guid.NewGuid();

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
