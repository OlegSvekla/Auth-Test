namespace IRLIX.Web.Models.Rqs;

public record SearchQueryRq(
    int? Amount,
    int? Offset,
    string? SortBy,
    string? FilterBy
    );

public class SearchQueryRqValidator
    : AbstractValidator<SearchQueryRq>
{
    public SearchQueryRqValidator()
    {
        RuleFor(x => x.Amount).InclusiveBetween(Ef.Consts.MinAmount, Ef.Consts.MaxAmount);
        RuleFor(x => x.Offset).InclusiveBetween(Ef.Consts.MinOffset, Ef.Consts.MaxOffset);
        RuleFor(x => x.SortBy).NotEmpty().When(x => !string.IsNullOrEmpty(x.SortBy));
        RuleFor(x => x.FilterBy).NotEmpty().When(x => !string.IsNullOrEmpty(x.FilterBy));
    }
}
