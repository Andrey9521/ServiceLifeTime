using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Services;
namespace ServiceLifeTime.Controllers;

public class TavernController : Controller
{
    private readonly ITavernKeeperService _tavernKeeper;
    private readonly IVisitService _visitService;
    private readonly IDiceService _diceService;
    
    public TavernController(
        ITavernKeeperService tavernKeeper,
        IVisitService visitService,
        IDiceService diceService)
    {
        _tavernKeeper = tavernKeeper;
        _visitService = visitService;
        _diceService = diceService;
    }
    public IActionResult Index()
    {
        _tavernKeeper.RegisterVisitor();
        
        _visitService.AddOrder("Медовуха", 12.5m);
        _visitService.AddOrder("Свиняча рулька", 25.0m);
        
        int roll1 = _diceService.Roll(20);
      

        ViewData["TavernName"] = _tavernKeeper.Name;
        ViewData["TotalVisitors"] = _tavernKeeper.TotalVisitors;
        ViewData["VisitId"] = _visitService.VisitId;
        ViewData["TotalBill"] = _visitService.TotalBill;

        ViewData["DiceRoll20"] = roll1;

        ViewData["LastRoll"] = _diceService.LastRoll;

        return View();
    }
}