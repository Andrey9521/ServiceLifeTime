namespace ServiceLifeTime.Services;

public interface IOperationService
{
    Guid OperationId { get; }
    int RequestCount { get; }
    void Increment();
}

public class OperationService : IOperationService
{
    public Guid OperationId { get; } = Guid.NewGuid();
    public int RequestCount { get; private set; } = 0; 

    public void Increment()
    {
        RequestCount++;
    }

    public OperationService()
    {
        Console.WriteLine($"Створили екземпляр класу: {OperationId.ToString()}");
    }
}

public interface ITransientService : IOperationService {}
public interface IScopedService : IOperationService {}
public interface ISingletonService : IOperationService {}


public class TransientService : OperationService, ITransientService {}
public class ScopedService : OperationService, IScopedService {}
public class SingletonService : OperationService, ISingletonService {}
