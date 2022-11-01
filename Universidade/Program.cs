using Universidade.Data;
using Microsoft.EntityFrameworkCore;
using Universidade.Services.ServiceCurso;
using Universidade.Services.ServiceInstituicao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<DataContext, DataContext>();

builder.Services.AddTransient<IInstituicaoService, InstituicaoService>();
builder.Services.AddTransient<ICursoService, CursoService>();

var app = builder.Build();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
