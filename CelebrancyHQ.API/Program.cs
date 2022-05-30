using CelebrancyHQ.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

app.UseAuthorization();

app.MapControllers();

app.Run();