using Core.Interfaces.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string NameEn { get; set; } = string.Empty;
        [MaxLength(100)]
        public string NameAr { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }
        public virtual User? Creator { get; set; }
    }
}
