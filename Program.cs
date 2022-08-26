var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Requisição feita com o verbo GET");
app.MapPost("/", (Product product) =>
{
    Console.WriteLine(product);
    return Results.Ok(product);
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
app.MapPost("/req-res", async (ctx) =>
{
    var json = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
    Console.WriteLine(json);
    ctx.Response.StatusCode = 201;
    ctx.Response.Headers.Add("content-type", "application/json");
    await ctx.Response.WriteAsync("{\"message\": \"teste\"}");
});

app.Run();

record Product(string Name, string Description, decimal Price);