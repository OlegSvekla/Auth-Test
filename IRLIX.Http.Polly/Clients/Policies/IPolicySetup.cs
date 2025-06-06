using Polly;

namespace IRLIX.Http.Polly.Clients.Policies;

public interface IPolicySetup
{
    PipelineOrderEnum PipelineOrder { get; }

    ResiliencePipelineBuilder<HttpResponseMessage> SetPolicy(
        ResiliencePipelineBuilder<HttpResponseMessage> pb);
}
