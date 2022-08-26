namespace TWTodos.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }
}