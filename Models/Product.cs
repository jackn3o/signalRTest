using System.ComponentModel.DataAnnotations;


namespace SignalR.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool IsPublished { get; set; }
    }
}