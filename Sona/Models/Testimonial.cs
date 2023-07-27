using System;
using System.Collections.Generic;

namespace Sona.Models;

public partial class Testimonial
{
    public int Id { get; set; }

    public string NameUser { get; set; } = null!;

    public int CountStar { get; set; }

    public string? TextTestimonial { get; set; }
}
