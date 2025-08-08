using TheProject.Components;
using TheProject.RandomPicture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHostedService<RandomPictureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

if (!app.Environment.IsDevelopment())
{
  string port = Environment.GetEnvironmentVariable("PORT") ?? "";
  Console.WriteLine($"Server started in port {port}");
  app.Run($"http://*:{port}");
}
else
{
  app.Run();
}
