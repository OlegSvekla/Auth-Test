namespace IRLIX.Ef.Models.Interfaces;

public interface IEntityCreatedUpdatedDates : IEntityCreatedDate
{
    DateTimeOffset UpdatedDate { get; set; }

    Guid? UpdatedByUserId { get; set; }
}
