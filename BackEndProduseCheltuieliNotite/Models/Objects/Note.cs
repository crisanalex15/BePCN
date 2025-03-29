using System.ComponentModel.DataAnnotations;

namespace BackEndProduseCheltuieliNotite.Models.Objects;
public class Note
{
    [Key]
    public int Id { get; set; }
    public string? Content { get; set; }
}

