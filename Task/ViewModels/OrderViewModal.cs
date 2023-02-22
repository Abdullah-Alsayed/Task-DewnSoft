using System.ComponentModel.DataAnnotations;

namespace Task.ViewModels
{
    public class OrderViewModal
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public decimal TotalOrder { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public string Items { get; set; }
        public string quantity { get; set; }
    }
}
