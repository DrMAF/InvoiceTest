using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Users
{
    public class VerifyRefreshToken
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
