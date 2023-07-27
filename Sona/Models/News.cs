using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sona.Models;

public partial class News
{
    public int Id { get; set; }

    public string Title1 { get; set; } = null!;

    public string? Title2 { get; set; }

    public string? Title3 { get; set; }

    public string? Title4 { get; set; }

    public string ParagraphText1 { get; set; } = null!;

    public string? ParagraphText2 { get; set; }

    public string? ParagraphText3 { get; set; }

    public string? ParagraphText4 { get; set; }

    public string? ParagraphText5 { get; set; }

    public string PhotoPath1 { get; set; } = null!;

    public string? PhotoPath2 { get; set; }

    public string? PhotoPath3 { get; set; }

    public string? PhotoPath4 { get; set; }

    public string? PhotoPath5 { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateWrite { get; set; }

    public string Writer { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
