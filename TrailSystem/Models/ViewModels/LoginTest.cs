using System.ComponentModel.DataAnnotations;

namespace TrailSystem.Models.ViewModels
{
    public class LoginTest
    {
            [Required(ErrorMessage = "Name is required.")]
            public string? Username { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }
    }
}
}
