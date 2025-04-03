using System.ComponentModel.DataAnnotations;
namespace BackEndProduseCheltuieliNotite.Models.Objects
{

    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
