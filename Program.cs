var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Requisição feita com o verbo GET");
app.MapPost("/", () => "Requisição feita com o verbo POST");
app.MapPut("/", () => "Requisição feita com o verbo PUT");
app.MapDelete("/", () => "Requisição feita com o verbo DELETE");
app.MapMethods("/", new[] { "PATCH", "OPTIONS" }, () => "Requisição feita com o verbo PATCH ou OPTIONS");

app.Run();
