namespace KhumaloWebApplication.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
