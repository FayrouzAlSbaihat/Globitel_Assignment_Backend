using FayrouzGlobitelAssignmentFullStack.data;
using FayrouzGlobitelAssignmentFullStack.Models;
using FayrouzGlobitelAssignmentFullStack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICompanyServices,CompanyServices>();
builder.Services.AddDbContext<SystemContext>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IComplainService,ComplainService>();
builder.Services.AddScoped<ISuggestionService,SuggestionService>();

builder.Services.AddIdentity<ApplicationUsers, IdentityRole>().
    AddEntityFrameworkStores<SystemContext>();



builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Account/Login";
    config.ExpireTimeSpan = TimeSpan.FromDays(2);
});



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "User",
        ValidIssuer = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisMySecurityKey"))
    };
});


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("_LoginOrgin", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});



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

app.UseHttpsRedirection();

app.UseCors("_LoginOrgin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
