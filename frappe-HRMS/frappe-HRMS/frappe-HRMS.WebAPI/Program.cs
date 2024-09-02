using frappe_HRMS.Infrastructure.Context;
using frappe_HRMS.Services.Interfaces;
using frappe_HRMS.Services.Interfaces.Company;
using frappe_HRMS.Services.Interfaces.Employee;
using frappe_HRMS.Services.Services;
using frappe_HRMS.Services.Services.Company;
using frappe_HRMS.Services.Services.Employee;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<HRMSDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(HRMSDbContext).Assembly.FullName)));

#region Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISignupRepository, SignupRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDesignationRepository,DesignationRepository>();
builder.Services.AddScoped<IEmploymentTypeRepository, EmploymentTypeRepository>();
builder.Services.AddScoped<IEmployeeGradeRepository, EmployeeGradeRepository>();
builder.Services.AddScoped<IEmployeeGroupRepository, EmployeeGroupRepository>();
#endregion

builder.Services.AddSwaggerGen();

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
