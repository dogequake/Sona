using System;
using System.Collections.Generic;

namespace Sona.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name_Category { get; set; }

    public virtual ICollection<News> News { get; } = new List<News>();
}
