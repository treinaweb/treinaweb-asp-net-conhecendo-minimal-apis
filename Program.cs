var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Requisição feita com o verbo GET");
app.MapPost("/", (Product product) =>
{
    Console.WriteLine(product);
    return "Requisição feita com o verbo POST";
});
app.MapPut("/", () => "Requisição feita com o verbo PUT");
app.MapDelete("/", () => "Requisição feita com o verbo DELETE");
app.MapMethods("/", new[] { "PATCH", "OPTIONS" }, () => "Requisição feita com o verbo PATCH ou OPTIONS");
app.MapGet("/products/{id}", (int id, string? search) =>
{
    Console.WriteLine(id);
    Console.WriteLine(search);
    return "Recebendo route values e query strings";
});

app.Run();

record Product(string Name, string Description, decimal Price);