namespace ServiceLifeTime.Services;

public interface IVisitService
{
    string VisitId { get; }
    List<string> Orders { get; }
    decimal TotalBill { get; }
    void AddOrder(string item, decimal price);
}

public class VisitService : IVisitService
{
    public string VisitId { get; private set; }
    public List<string> Orders { get; private set; }
    public decimal TotalBill { get; private set; }

    public VisitService()
    {
        VisitId = $"Visit-{Guid.NewGuid().ToString()[..8]}";
        Orders = new List<string>();
        TotalBill = 0;
    }
    
    public void AddOrder(string item, decimal price)
    {
        if (string.IsNullOrWhiteSpace(item))
            throw new ArgumentException("Назва товару не може бути порожньою");

        if (price < 0)
            throw new ArgumentException("Ціна не може бути від'ємною");

        Orders.Add(item);
        TotalBill += price;

        Console.WriteLine($"[{VisitId}] Замовлено: {item} ({price} зол.) | Загалом: {TotalBill} зол.");
    }
}

