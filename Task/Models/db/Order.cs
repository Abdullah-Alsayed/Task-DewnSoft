using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models.db
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public decimal TotalOrder { get; set; }
        public DateTime CreatineDate { get; set; }
        [Required]
        public int ItemCount {get;set; }
        public virtual ICollection<Item_Order> itemOrders { get; set; }

    }
}
