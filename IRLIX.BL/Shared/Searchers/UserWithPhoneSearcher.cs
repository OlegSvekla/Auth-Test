using IRLIX.Core.Entities;
using IRLIX.Core.IRLIX.Web.Identity.Lockouts.Models;
using IRLIX.Repository.Repository.Interfaces.Common;
using IRLIX.Repository.Repository.Interfaces.Enums;
using System.Linq.Expressions;
using IRLIX.Core.Core.General;

namespace IRLIX.BL.Shared.Modifiers.Searchers;

public class UserWithPhone
{
    public Guid UserId { get; set; }

    public LockoutDto Lockout { get; set; } = default!;

    public string? UserName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? HardcodedCode { get; set; }
}

public interface IUserWithPhoneSearcher
{
    Task<UserWithPhone> ValidateAndGetAsync(
        string phone,
        string deviceId,
        CancellationToken ct);

    Task<UserWithPhone> ValidateAndGetAsync(
        Guid userId,
        string phone,
        CancellationToken ct);
}

internal class UserWithPhoneSearcher(
    IRepository<UserEntity> userRepository
    ) : IUserWithPhoneSearcher
{
    public async Task<UserWithPhone> ValidateAndGetAsync(
        string phone,
        string deviceId,
        CancellationToken ct)
    {
        //TODO: implement ip validator to block in case of multiple calls

        var userByPhoneDtos = await userRepository.GetAllAsync(
            predicate: user => user.PhoneNumber == phone,
            selector: UserWithPhoneSelector,
            ct: ct);
        if (userByPhoneDtos.IsOneItemCollection())
        {
            return userByPhoneDtos.Single();
        }

        if (!userByPhoneDtos.Any())
        {
            throw UserNotFoundByPhoneException.CreateWhenNotFound(phone);
        }

        var userWithDeviceIdDtos = await userRepository.GetAllAsync(
            predicate: user
                => user.PhoneNumber == phone
                && user.Sessions.Any(session => session.DeviceId == deviceId),
            selector: UserWithPhoneSelector,
            ct: ct);
        if (userWithDeviceIdDtos.IsOneItemCollection())
        {
            return userWithDeviceIdDtos.Single();
        }

        if (!userWithDeviceIdDtos.Any())
        {
            throw UserNotFoundByPhoneException.CreateWhenNotFound(phone);
        }

        throw MultipleUsersFoundByPhoneException.CreateWhenMultiple(phone);
    }

    public async Task<UserWithPhone> ValidateAndGetAsync(
        Guid userId,
        string phone,
        CancellationToken ct)
    {
        var userByPhoneDto = await userRepository.FindAsync(
            mode: SearchModeEnum.Single,
            predicate: user
                => user.Id == userId
                && user.PhoneNumber == phone,
            selector: UserWithPhoneSelector,
            ct: ct);
        return userByPhoneDto
            ?? throw UserNotFoundByPhoneException.CreateWhenNotFound(phone);
    }

    private static Expression<Func<UserEntity, UserWithPhone>> UserWithPhoneSelector
        => user => new UserWithPhone
        {
            UserId = user.Id,
            Lockout = new LockoutDto
            {
                Enabled = user.LockoutEnabled,
                EndDate = user.LockoutEnd,
                Reason = user.LockoutReason,
                CreatedDate = user.LockoutCreatedDate,
                CreatedByUserId = user.LockoutCreatedByUserId
            },
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            HardcodedCode = user.HardcodedCode
        };
}
