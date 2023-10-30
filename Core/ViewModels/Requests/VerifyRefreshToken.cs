using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.Requests
{
    public class VerifyRefreshToken
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
