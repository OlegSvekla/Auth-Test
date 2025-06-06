using IRLIX.Ef.Identity.Models;
using IRLIX.Web.Identity.Otps.Totps;
using Microsoft.AspNetCore.Identity;

namespace IRLIX.Web.Identity.Otps;

public static class Bootstrap
{
    public static IdentityBuilder AddBatchWebIdentityOtps<TUser>(
        this IdentityBuilder identityBuilder)
        where TUser : EfIdentityUserEntity
    {
        identityBuilder
            .AddTokenProvider<FourDigitEmailTokenProvider<TUser>>(Consts.FourDigitEmailProvider)
            .AddTokenProvider<FourDigitPhoneNumberTokenProvider<TUser>>(Consts.FourDigitPhoneProvider);

        return identityBuilder;
    }
}
