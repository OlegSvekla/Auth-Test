namespace IRLIX.Repository.Ef.Models.Interfaces;

public interface IEntityCreatedDate
{
    DateTimeOffset CreatedDate { get; set; }

    Guid? CreatedByUserId { get; set; }
}
