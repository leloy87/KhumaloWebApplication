using System.ComponentModel.DataAnnotations;

namespace KhumaloWebApplication.Models
{
    public class LoginModel
    {
        public class InputModel
        {
            [Required]
            [EmailAddress]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }


        }
    }
}

