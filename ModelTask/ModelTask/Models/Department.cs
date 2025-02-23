using System;
using System.Collections.Generic;

namespace ModelTask.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public DateOnly? YeareOfEstablishment { get; set; }

    public int? NumberOfEmployees { get; set; }
}
