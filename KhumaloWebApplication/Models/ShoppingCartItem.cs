namespace KhumaloWebApplication.Models
{
    public class ShoppingCartItem
    {
        public int  ShoppingCartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public  ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}
