namespace TodoApp;

public class TodoList
{
    public record TodoItem(string Content)
    {
        public int Id { get; init; }
        public bool Complete { get; init; }
    }
    private readonly List<TodoItem> _todoItems = [];
    private int idCounter = 1;

    //Add Todo Item
    public void Add(TodoItem item)
    {
        _todoItems.Add(item with { Id = idCounter++ });
    }
    //Get all Todo Item
    public IEnumerable<TodoItem> Get => _todoItems;

    //Complete or delete a TodoItem
    public void Complete(int id)
    {
        var item = _todoItems.First(x => x.Id == id);
        _todoItems.Remove(item);

        var completedItem = item with { Complete = true };
        _todoItems.Add(completedItem);
    }
}