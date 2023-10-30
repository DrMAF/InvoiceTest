using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string SecondName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(50)]
        public string SaltKey { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Password { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }
        public virtual User? Creator { get; set; }
    }
}
