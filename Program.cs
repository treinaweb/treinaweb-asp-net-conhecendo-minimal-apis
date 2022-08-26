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

app.Run();