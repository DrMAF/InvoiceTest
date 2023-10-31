using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? SecondName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? UserName { get; set; }
        [MaxLength(50)]
        public string? Phone { get; set; }
        [MaxLength(50)]
        public string? SaltKey { get; set; }
        [MaxLength(500)]
        public string? Password { get; set; }
        [MaxLength(1000)]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }
        public virtual User? Creator { get; set; }
    }
}
