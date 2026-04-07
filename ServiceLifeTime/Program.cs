using ServiceLifeTime.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//-------------------------------------
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddScoped<HelperService>();
//-------------------------------------

builder.Services.AddSingleton<ITavernKeeperService, TavernKeeperService>();
builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddTransient<IDiceService, DiceService>();

//-------------------------------------
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Tavern}/{action=Index}/{id?}");


app.Run();