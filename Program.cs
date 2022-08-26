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

app.Run();