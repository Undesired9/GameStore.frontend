using GameStore.Frontend.Components;
using GameStore.Frontend.Clients;

var builder = WebApplication.CreateBuilder(args);

var apiUrl = builder.Configuration.GetValue<string>("ApiUrl")
    ?? throw new InvalidOperationException("ApiUrl is not configured in appsettings.json.");

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient<GamesClient>(client =>
    client.BaseAddress = new Uri(apiUrl));
builder.Services.AddHttpClient<GenresClient>(client =>
    client.BaseAddress = new Uri(apiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
