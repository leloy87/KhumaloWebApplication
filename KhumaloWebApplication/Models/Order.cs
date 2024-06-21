namespace KhumaloWebApplication.Models
{
    public enum OrderStatus
    {
        Pending,
        Processed,
        Shipped,
        Delivered,
        Cancelled
        
    }

    public class Order
    {
        public int OrderId { get; set; }    
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } 

        public List<OrderItem> OrderItems { get; set; }


    }
}

