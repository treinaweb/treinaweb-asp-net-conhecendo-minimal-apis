using TWTodos.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TWTodoContext>();

var app = builder.Build();

app.Run();