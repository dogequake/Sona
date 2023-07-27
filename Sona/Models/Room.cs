using System;
using System.Collections.Generic;

namespace Sona.Models;

public partial class Room
{
    public int Id { get; set; }

    public string NameRoom { get; set; } = null!;

    public string PriceRoom { get; set; } = null!;

    public int SizeRoom { get; set; }

    public int CapacityRoom { get; set; }

    public string BedRoom { get; set; } = null!;

    public string? DescriptionRoom { get; set; }

    public double? RateRoom { get; set; }
}
