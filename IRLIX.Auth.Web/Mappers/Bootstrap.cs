using IRLIX.Auth.Contracts.Commands.OtpConfirms;
using IRLIX.Auth.Contracts.Commands.OtpVerifies;
using IRLIX.Auth.Contracts.Commands.SignIns;
using IRLIX.Auth.Contracts.Commands.SignUps;
using IRLIX.Auth.Contracts.Commands.TokenUpdates;
using IRLIX.Auth.Contracts.Commands.Users;
using IRLIX.Auth.Contracts.Commands.VerifyCodes;
using IRLIX.Auth.Contracts.Queries;
using IRLIX.Auth.Contracts.Queries.Sessions;
using IRLIX.Auth.Contracts.Queries.TokenUpdates;
using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Auth.Contracts.Queries.VerifyCodes;
using IRLIX.Auth.Web.Mappers.OtpConfirms;
using IRLIX.Auth.Web.Mappers.OtpVerifies;
using IRLIX.Auth.Web.Mappers.Sessions;
using IRLIX.Auth.Web.Mappers.SignIns;
using IRLIX.Auth.Web.Mappers.SignUps;
using IRLIX.Auth.Web.Mappers.TokenUpdates;
using IRLIX.Auth.Web.Mappers.Users;
using IRLIX.Auth.Web.Mappers.VerifyCodes;
using IRLIX.Auth.Web.Models.Rqs.OtpConfirms;
using IRLIX.Auth.Web.Models.Rqs.OtpVerifies;
using IRLIX.Auth.Web.Models.Rqs.Sessions;
using IRLIX.Auth.Web.Models.Rqs.SignIns;
using IRLIX.Auth.Web.Models.Rqs.SignUps;
using IRLIX.Auth.Web.Models.Rqs.TokenUpdates;
using IRLIX.Auth.Web.Models.Rqs.Users;
using IRLIX.Auth.Web.Models.Rqs.VerifyCodes;
using IRLIX.Auth.Web.Models.Rss;
using IRLIX.Auth.Web.Models.Rss.Sessions;
using IRLIX.Auth.Web.Models.Rss.Users;
using IRLIX.Core.Interfaces.Mappers;
using IRLIX.Web.Models.Rqs;

namespace IRLIX.Auth.Web.Mappers;

internal static class Bootstrap
{
    internal static IServiceCollection AddAuthWebMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapper<ConfirmMeOtpViaEmailBodyRq, ConfirmMeOtpViaEmailCommand>, ConfirmMeOtpViaEmailBodyRqToCommandMapper>();

        services.AddScoped<IMapper<VerifyConfirmByMeViaEmailBodyRq, VerifyConfirmByMeViaEmailCommand>, VerifyConfirmByMeViaEmailBodyRqToCommandMapper>();

        services.AddScoped<IMapper<GetUserSessionsRq, GetUserSessionsQuery>, GetUserSessionsRqToQueryMapper>();
        services.AddScoped<IMapper<IReadOnlyCollection<SessionQueryRs>, IReadOnlyCollection<SessionRs>>, SessionQueryRssToRssMapper>();

        services.AddScoped<IMapper<SignMeInViaEmailBodyRq, SignMeInViaEmailCommand>, SignMeInViaEmailBodyRqToCommandMapper>();

        services.AddScoped<IMapper<SignMeUpBodyRq, SignMeUpCommand>, SignMeUpBodyRqToCommandMapper>();

        services.AddScoped<IMapper<SignMeOutBodyRq, SignMeOutCommand>, SignMeOutBodyRqToCommandMapper>();
        services.AddScoped<IMapper<UpdateMyAccessTokenByRefreshTokenBodyRq, UpdateMyAccessTokenByRefreshTokenCommand>, UpdateMyAccessTokenByRefreshTokenBodyRqToCommandMapper>();
        services.AddScoped<IMapper<Guid, UpdateMyAccessTokenByRefreshTokenQuery>, UpdateMyAccessTokenByRefreshTokenCommandIdToQueryMapper>();

        services.AddScoped<IMapper<GetMyUserQueryRs, GetMyUserRs>, GetMyUserQueryRsToRsMapper>();
        services.AddScoped<IMapper<IReadOnlyCollection<GetUsersQueryRs>, IReadOnlyCollection<GetUsersRs>>, GetUsersQueryRssToRssMapper>();
        services.AddScoped<IMapper<SearchWithDeletedQueryRq, GetUsersQuery>, SearchWithDeletedQueryRqToGetUsersQueryMapper>();
        services.AddScoped<IMapper<SetUserLockoutRq, SetUserLockoutCommand>, SetUserLockoutRqToCommandMapper>();

        services.AddScoped<IMapper<VerifyCodeByMeViaEmailBodyRq, VerifyCodeByMeViaEmailCommand>, VerifyCodeByMeViaEmailBodyRqToCommandMapper>();
        services.AddScoped<IMapper<Guid, VerifyCodeByMeViaEmailQuery>, VerifyCodeByMeViaEmailCommandIdToQueryMapper>();

        services.AddScoped<IMapper<AuthTokensQueryRs, AuthTokensRs>, AuthTokensQueryRsToRsMapper>();

        return services;
    }
}
