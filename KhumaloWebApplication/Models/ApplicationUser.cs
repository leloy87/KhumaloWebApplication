using Microsoft.AspNetCore.Identity;

namespace KhumaloWebApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ShoppingCart ShoppingCart { get; set; }
        
    }
}
