using SGI.UI;
using SGI.Aplicacion;
using SGI.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios para Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options => options.DetailedErrors = true);

// Servicios para Usuarios
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddScoped<ServicioAutorizacion>();
builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();
builder.Services.AddScoped<CasoDeUsoUsuarioBaja>();
builder.Services.AddScoped<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddScoped<MostrarUsuarios>();
builder.Services.AddScoped<CasoDeUsoUsuarioModificar>(); 
builder.Services.AddSingleton<Usuario>();
// Servicios para Categorias
builder.Services.AddSingleton<ICategoriaRepositorio, RepositorioCategoria>();
builder.Services.AddScoped<DarAltaCategoria>();
builder.Services.AddScoped<DarBajaCategoria>();
builder.Services.AddScoped<ModificarCategoria>();
builder.Services.AddScoped<MostrarCategorias>();
// Servicios para Productos
builder.Services.AddSingleton<IProductoRepositorio,RepositorioProducto>();
builder.Services.AddScoped <DarAltaProducto>();
builder.Services.AddScoped<DarBajaProducto>();
builder.Services.AddScoped<ModificarProducto>();
builder.Services.AddScoped<ProductoValidador>();
builder.Services.AddScoped<ListarProductos>();
// Servicios para Transacciones
builder.Services.AddSingleton<ITransaccionRepositorio, RepositorioTransaccion>();
builder.Services.AddScoped<RepositorioTransaccion>();
builder.Services.AddScoped<DarAltaTransaccion>();
builder.Services.AddScoped<DarBajaTransaccion>();
builder.Services.AddScoped<ListarTransacciones>(); 

// Configurar el middleware y pipeline
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();