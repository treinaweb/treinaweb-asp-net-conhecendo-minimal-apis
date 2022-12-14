using TWTodos.Data.Contexts;
using TWTodos.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TWTodoContext>();

var app = builder.Build();

app.MapPost("/api/todos", (Todo todo, TWTodoContext context) =>
{
    context.Todos.Add(todo);
    context.SaveChanges();
    return Results.Created($"/api/todos/{todo.Id}", todo);
});
app.MapGet("/api/todos", (TWTodoContext context) => Results.Ok(context.Todos));
app.MapGet("/api/todos/{id}", (int id, TWTodoContext context) =>
{
    var todo = context.Todos.Find(id);
    return todo is null ? Results.NotFound() : Results.Ok(todo);
});
app.MapDelete("/api/todos/{id}", (int id, TWTodoContext context) =>
{
    var todo = context.Todos.Find(id);
    if (todo is null)
    {
        return Results.NotFound();
    }
    context.Remove(todo);
    context.SaveChanges();
    return Results.NoContent();
});
app.MapPut("/api/todos/{id}", (int id, Todo todo, TWTodoContext context) =>
{
    if (!context.Todos.Any(t => t.Id == id))
    {
        return Results.NotFound();
    }
    todo.Id = id;
    context.Todos.Update(todo);
    context.SaveChanges();
    return Results.Ok(todo);
});

app.Run();