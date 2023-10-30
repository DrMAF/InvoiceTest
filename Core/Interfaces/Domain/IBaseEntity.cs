namespace Core.Interfaces.Domain
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string NameEn { get; set; }
        string NameAr { get; set; }
        string Description { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        int? CreatorId { get; set; }
    }
}
