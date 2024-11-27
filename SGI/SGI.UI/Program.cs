using SGI.UI.Components;
using SGI.Aplicacion;
using SGI.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options => options.DetailedErrors = true);

// Usuarios.w1
builder.Services.AddSingleton<IUsuarioRepositorio,RepositorioUsuario>();
builder.Services.AddSingleton<BuscarUsuario>();
builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();
builder.Services.AddScoped<CasoDeUsoUsuarioBaja>();
builder.Services.AddScoped<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddScoped<MostrarUsuarios>();
// Categorias.
builder.Services.AddSingleton<ICategoriaRepositorio,RepositorioCategoria>();

builder.Services.AddScoped<DarAltaCategoria>();
builder.Services.AddScoped<DarBajaCategoria>();
builder.Services.AddScoped<ModificarCategoria>();
builder.Services.AddScoped<CategoriaValidador>();

// Productos

builder.Services.AddSingleton<IProductoRepositorio,RepositorioProducto>();
builder.Services.AddScoped <DarAltaProducto>();
builder.Services.AddScoped<DarBajaProducto>();
builder.Services.AddScoped<ModificarProducto>();
builder.Services.AddScoped<ProductoValidador>();

// Transaccion
builder.Services.AddSingleton<ITransaccionRepositorio, RepositorioTransaccion>();
builder.Services.AddScoped<RepositorioTransaccion>();
builder.Services.AddScoped<DarAltaTransaccion>();
builder.Services.AddScoped<DarBajaTransaccion>();
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
