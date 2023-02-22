namespace Task.Models.db
{
    public class Item_Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order order { get; set; }
        public int quantity { get; set; }
        public int ItemId { get; set; }
        public Item item { get; set; }
    }
}
