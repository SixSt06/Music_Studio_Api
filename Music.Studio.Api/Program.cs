using Music.Studio.Api.DataAccess;
using Music.Studio.Api.DataAccess.Interfaces;
using Music.Studio.Api.Repositories;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services;
using Music.Studio.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();

builder.Services.AddScoped<IEquipmentReservationRepository, EquipmentReservationRepository>();
builder.Services.AddScoped<IEquipmentReservationService, EquipmentReservationService>();

builder.Services.AddScoped<iSessionRespository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();

builder.Services.AddScoped<IProjectRepositoy,ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IInvoicesRepository,InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
    
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDbContext, DbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();