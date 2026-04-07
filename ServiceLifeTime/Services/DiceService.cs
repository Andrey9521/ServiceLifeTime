namespace ServiceLifeTime.Services;

public interface IDiceService
{
    int LastRoll { get; }
    int Roll(int sides = 20);
}

public class DiceService : IDiceService
{
    private static readonly Random _random = new Random();
    public int LastRoll { get; private set; } = 0;

    public DiceService()
    {
        LastRoll = Roll(20);

        Console.WriteLine($"🎲 Кубик створено (Transient). Перший кидок: d20 = {LastRoll}");
    }
    
    public int Roll(int sides = 20)
    {
        if (sides < 2)
            throw new ArgumentException("Кубик повинен мати мінімум 2 грані", nameof(sides));

        int result = _random.Next(1, sides + 1);
        LastRoll = result;

        Console.WriteLine($"🎲 Кидок! d{sides} → {result}");
        return result;
    }
}

