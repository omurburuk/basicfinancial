
using BasicFinancial.Core;
using BasicFinancial.Core.Services;
using BasicFinancial.Data; 
using BasicFinancial.Helper;
using BasicFinancial.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models; 
using System.Configuration;
using System.Data.Common;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<ConnectionStringSettings>(builder.Configuration.GetSection("ConnectionStrings"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicFinancial API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.RequireHttpsMetadata = false;
           options.SaveToken = true;
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("147B63D7FC5D5ECAAEFD65FF72AFB")),
               ValidateIssuer = false,
               ValidateAudience = false,
               ClockSkew = TimeSpan.Zero
           };
       });
 
builder.Services.AddScoped<FinancialDbContext>(); 
builder.Services.AddDbContext<FinancialDbContext>(); 
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();  
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<FinancialDbContext>();
   
    dbContext.Database.Migrate();
} 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
