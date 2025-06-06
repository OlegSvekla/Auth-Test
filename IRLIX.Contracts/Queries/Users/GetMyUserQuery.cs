using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Queries.Users;

public record GetMyUserQuery()
    : IMediatrQuery<GetMyUserQueryRs>;

public record GetMyUserQueryRs(
    string? Phone,
    bool IsPhoneVerified,
    string? Email,
    bool IsEmailVerified
    );
