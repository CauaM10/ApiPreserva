using Api.Data;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Contexto>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped <ICadastroEmpresaRepositorio, CadastroEmpresaRepositorio>();

builder.Services.AddScoped<ITipoCombustivelRepositorio, TipoCombustivelRepositorio>();

builder.Services.AddScoped<IMotoristaRepositorio, MotoristaRepositorio>();

builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();

builder.Services.AddScoped<ILugarRepositorio, LugarRepositorio>();

builder.Services.AddScoped<ISobreNosRepositorio, SobreNosRepositorio>();

builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();

builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();

builder.Services.AddScoped<IKmsRodadosRepositorio, KmsRodadosRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
