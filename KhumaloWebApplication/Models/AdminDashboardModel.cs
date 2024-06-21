using Microsoft.AspNetCore.Authorization;

namespace KhumaloWebApplication.Models
{

    [Authorize(Roles = "Admin")]
    public class AdminDashboardModel
    {

        public void OnGet()
        {
            // Add any neccessary logic here
        }
    }
}