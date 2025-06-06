using Hangfire;

namespace IRLIX.Jobs.Hangfire;

public interface IDbConnectionProvider
{
    IGlobalConfiguration AddDbConnection(IGlobalConfiguration config);
}
