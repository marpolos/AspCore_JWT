using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<IConfiguration>(Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => 
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      // Issuer : emissor
      // Audience : audiência
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "MarcelleByMacoratti",
        ValidAudience = "MinhaAudiencia",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecreta"))
    };
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authenticate conecta o middleware de autenticação ao pipe de Http
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
