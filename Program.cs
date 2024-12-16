
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<api_dicsys.Controllers.ConexionDB>();
builder.Services.AddScoped<api_dicsys.dao.ProductosDAO>();
// Add services to the container.

// Agregar la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        // Permitir solicitudes desde un origen específico (por ejemplo, tu frontend)
        policy.AllowAnyOrigin() //WithOrigins("https://tudominio.com")  // Agrega el origen de tu frontend
              .AllowAnyMethod()  // Permite cualquier método (GET, POST, PUT, DELETE, etc.)
              .AllowAnyHeader(); // Permite cualquier encabezado
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar CORS
app.UseCors("AllowSpecificOrigin"); // Aplica la política de CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
