using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class AuthenticationToken : BaseEntity
    {
        public int UserId { get; set; }
        [MaxLength(2000)]
        public string? AccessToken { get; set; }
        [MaxLength(1000)]
        public string? RefreshToken { get; set; }
    }
}
