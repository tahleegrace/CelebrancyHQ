using Microsoft.OpenApi.Models;

using CelebrancyHQ.Auditing;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Mappings;
using CelebrancyHQ.Repository;
using CelebrancyHQ.Services;
using CelebrancyHQ.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddBearerAuthentication(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingsSetup).Assembly);
builder.Services.AddDbContext<CelebrancyHQContext>();
builder.Services.AddCelebrancyHQRepositories();
builder.Services.AddCelebrancyHQAuditingServices();
builder.Services.AddCelebrancyHQServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Value.Split(","))
                  .AllowCredentials().WithHeaders(builder.Configuration.GetSection("AllowedHeaders").Value.Split(","))
                  .WithMethods(builder.Configuration.GetSection("AllowedMethods").Value.Split(",")));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();