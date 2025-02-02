﻿namespace KhumaloWebApplication.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Products Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
