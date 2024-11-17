using SGI.UI.Components;
using SGI.Aplicacion;
using SGI.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUsuarioRepositorio,RepositorioUsuario>();

builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
