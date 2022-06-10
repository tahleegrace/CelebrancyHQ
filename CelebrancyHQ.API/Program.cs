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
builder.Services.AddSwaggerGen();
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