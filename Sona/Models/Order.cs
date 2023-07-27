using System;
using System.Collections.Generic;

namespace Sona.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime DateCheckin { get; set; }

    public DateTime DateCheckout { get; set; }

    public string CountGuest { get; set; } = null!;

    public string CountRoom { get; set; } = null!;

    public string? NameClient { get; set; }

    public string? PhonenumClient { get; set; }
}
