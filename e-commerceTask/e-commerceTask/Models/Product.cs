﻿using System;
using System.Collections.Generic;

namespace e_commerceTask.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }
}
