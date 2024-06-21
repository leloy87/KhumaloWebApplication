using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace KhumaloWebApplication.Services
{
    public interface IRoleInitializer
    {
        Task InitializeAsync();
    }
 
    public class RoleInitializer : IRoleInitializer
    { 
        private readonly RoleManager<IdentityRole> _roleManager;

    public RoleInitializer(RoleManager<IdentityRole> roleManager)
    {
            _roleManager = roleManager;


    }
        public async Task InitializeAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }

        }

}
