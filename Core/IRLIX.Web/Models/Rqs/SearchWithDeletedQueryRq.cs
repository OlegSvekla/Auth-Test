namespace ShuttleX.Web.Models.Rqs;

public record SearchWithDeletedQueryRq(
    int? Amount,
    int? Offset,
    string? SortBy,
    string? FilterBy,
    bool? IncludeDeleted
    ) : SearchQueryRq(
        Amount,
        Offset,
        SortBy,
        FilterBy
        );

public class SearchWithDeletedQueryRqValidator : AbstractValidator<SearchWithDeletedQueryRq>
{
    public SearchWithDeletedQueryRqValidator()
    {
        RuleFor(x => x.Amount).InclusiveBetween(Ef.Consts.MinAmount, Ef.Consts.MaxAmount);
        RuleFor(x => x.Offset).InclusiveBetween(Ef.Consts.MinOffset, Ef.Consts.MaxOffset);
        RuleFor(x => x.SortBy).NotEmpty().When(x => !string.IsNullOrEmpty(x.SortBy));
        RuleFor(x => x.FilterBy).NotEmpty().When(x => !string.IsNullOrEmpty(x.FilterBy));
    }
}

