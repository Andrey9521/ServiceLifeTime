namespace ServiceLifeTime.Services;

public class HelperService
{
    public ITransientService Transient { get; }
    public IScopedService Scoped { get; }
    public ISingletonService Singleton { get; }

    public HelperService(ITransientService transientService, IScopedService scopedService,
        ISingletonService singletonService)
    {
        Transient = transientService;
        Scoped = scopedService;
        Singleton = singletonService;
    }
}