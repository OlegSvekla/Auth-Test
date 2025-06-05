namespace IRLIX.Core.Core.Interfaces.Mappers;

public interface IMapper<TInput, TOutput>
{
    TOutput Map(TInput input);
}
