using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.Configs;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.Contexts;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config => config.UseSqlServerStorage("Data Source=.\\SQLEXPRESS;Initial Catalog=TaskAssignerDB;User ID=sa;Password=sa; TrustServerCertificate=True ;MultipleActiveResultSets=true"));
builder.Services.AddHangfireServer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});


ConnectionConfig.ConnectionString = builder.Configuration.GetConnectionString("TaskAssignerContext");
builder.Services.AddScoped<DbContext, TaskAssignerContext>();
builder.Services.AddScoped<ITaskDal,EFTaskDal>(); 
builder.Services.AddScoped<IEmployeeDal,EFEmployeeDal>(); 
builder.Services.AddScoped<ITaskHistoryDal,EFTaskHistoryDal>();
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<ITaskHistoryService,TaskHistoryService>();
builder.Services.AddScoped<IAssignerService,AssignerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard();

app.UseCors("CorsPolicy");

RecurringJob.AddOrUpdate<AssignerService>("AssignerJob", assignerService => assignerService.CreateAssignJob(), "10 0 * * *");

app.UseAuthorization();

app.MapControllers();

app.Run();
