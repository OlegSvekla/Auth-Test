using IRLIX.Aggregator.Ef;
using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Auth.Web;
using IRLIX.Di.DependencyResolvers;
using IRLIX.Web.Startups;
using IRLIX.Web.Startups.Concrete;
using IRLIX.Web.Startups.Concrete.Comms;
using IRLIX.Web.Startups.Concrete.Contexts;
using IRLIX.Web.Startups.Concrete.Efs;
using IRLIX.Web.Startups.Concrete.Https;
using IRLIX.Web.Startups.Concrete.Identities;
using IRLIX.Web.Startups.Concrete.Jobs;
using IRLIX.Web.Startups.Concrete.L11ns;
using IRLIX.Web.Startups.Concrete.Loggers;
using IRLIX.Web.Startups.Concrete.Mqs;
using IRLIX.Web.Startups.Concrete.WebApis;
using IRLIX.Aggregator;

var builder = WebApplication.CreateBuilder(args);
var activator = new ActivatorDependencyResolver();
var app = await AppBuilder.New(activator)
    .With<Startup>()

    .With<CommEmailGmailStartup>()

    .With<ContextStartup>()
    .With<ContextWebStartup>()
    .With<ContextWebIdentityStartup>()

    .With<EfStartup>()
    .With<EfPostgreSqlStartup<GodContext>>()

    .With<HttpStartup>()
    .With<HttpPollyStartup>()

    .With<IdentityWebStartup<GodContext, UserEntity, RoleEntity, UserRoleEntity>>()

    .With<HangfireStartup>()
    .With<HangfirePostgreSqlStartup>()

    .With<L11nStartup>()

    .With<MqStartup>()
    .With<MqLocalMediatRStartup>()

    .With<ConfigurationStartup>()
    .With<DataProtectionStartup>()
    .With<ExceptionHandlerStartup>()
    .With<HstsStartup>()
    .With<RateLimitingStartup>()
    .With<ResponseHandlerStartup>()
    .With<RoutingStartup>()
    .With<SwaggerStartup>()
    .With<ValidationStartup>()
    .With<VersioningStartup>()
    .With<WebApiStartup>()

    .With<CoreStartup>()

    .With<AggregatorStartup>()
    //.With<UseJobsStartup>()

    .BuildAsync(builder);

await app.RunAsync();
