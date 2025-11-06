
// File: Models/Phone.cs
namespace PhoneCatalog.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public double Rating { get; set; }
        public string Description { get; set; } = "";
    }
}
