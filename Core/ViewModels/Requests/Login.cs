using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Requests
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
