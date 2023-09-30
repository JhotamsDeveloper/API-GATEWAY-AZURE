var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/demo01/mecanismo", () =>
{
    var random = Random.Shared.Next(-20, 55);
    var forecast = new
    {
        createMechanism = DateOnly.FromDateTime(DateTime.Now.AddDays(random)),
        random
    };

    return forecast;
})
.WithName("mecanismo_get")
.WithOpenApi();


app.MapPost("/demo02/mecanismo", (Mechanism mechanism) =>
{
    var random = Random.Shared.Next(-20, 55);
    var forecast = new
    {
        name = mechanism.Name,
        createMechanism = DateOnly.FromDateTime(DateTime.Now.AddDays(random)),
        random
    };
    return forecast;
})
.WithName("mecanismo_post")
.WithOpenApi();

app.Run();
public class Mechanism
{
    public string Name { get; set; }
}