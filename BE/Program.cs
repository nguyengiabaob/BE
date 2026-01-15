var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DBconnectionService>();
// Add services to the container.
builder.Services.AddSingleton<IAuthService, AuthService>();
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<DefaultService>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();
app.MapGet("/test-connection", async (DBconnectionService mongoDbConnection) =>
{
    var database = mongoDbConnection.Database;
    return Results.Ok($"Successfully connected to database: {database.DatabaseNamespace.DatabaseName}");
});
app.Run();
