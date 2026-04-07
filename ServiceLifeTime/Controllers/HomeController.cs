using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Services;

namespace ServiceLifeTime.Controllers;

public class HomeController : Controller
{
    private readonly ITransientService _transient;
    private readonly IScopedService _scoped;
    private readonly ISingletonService _singleton;
    private readonly HelperService _helper;

    public HomeController(
        ITransientService transientService,
        IScopedService scopedService,
        ISingletonService singletonService,
        HelperService helperService)
    {
        _transient = transientService;
        _scoped = scopedService;
        _singleton = singletonService;
        _helper = helperService;
        
        _singleton.Increment();
    }

    public IActionResult Index()
    {
        ViewBag.TransientController = _transient.OperationId.ToString()[..8];
        ViewBag.TransientHelper     = _helper.Transient.OperationId.ToString()[..8];
        ViewBag.TransientMath       = _transient.OperationId == _helper.Transient.OperationId;

        ViewBag.ScopedController    = _scoped.OperationId.ToString()[..8];
        ViewBag.ScopedHelper        = _helper.Scoped.OperationId.ToString()[..8];
        ViewBag.ScopedMath          = _scoped.OperationId == _helper.Scoped.OperationId;

        ViewBag.SingletonController = _singleton.OperationId.ToString()[..8];
        ViewBag.SingletonHelper     = _helper.Singleton.OperationId.ToString()[..8];
        ViewBag.SingletonMath       = _singleton.OperationId == _helper.Singleton.OperationId;

        ViewBag.SingletonCount      = _singleton.RequestCount.ToString();

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}