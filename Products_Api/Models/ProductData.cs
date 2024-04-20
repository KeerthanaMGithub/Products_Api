using System.ComponentModel.DataAnnotations;

namespace Products_Api.Models
{
    public class ProductData
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; } = "";
        [Required]
        public string description { get; set; } = "";
        [Required]
        public decimal price { get; set; } = 0;
    }
}
