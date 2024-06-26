using RentCard.Models.BD;
using RentCard.Repository.Interface;
using RentCard.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentCarDbContext>(options =>
{
    builder.Configuration.GetConnectionString("DBConnection");
});

builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins(
        "http://localhost:4200"
        )
    .AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PolicyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
