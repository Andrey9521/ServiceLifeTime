namespace ServiceLifeTime.Services;

public interface ITavernKeeperService
{
    string Name { get; }
    int TotalVisitors { get; }
    void RegisterVisitor();
}

public class TavernKeeperService : ITavernKeeperService
{
    public string Name { get; } = String.Empty;
    public int TotalVisitors { get; private set; } = 0;

    public void RegisterVisitor()
    {
        TotalVisitors++;
    }

    public TavernKeeperService()
    {
        Name = "Keeper";
        Console.WriteLine($"Створення конструктора: {Name} , час ");
    }
}


