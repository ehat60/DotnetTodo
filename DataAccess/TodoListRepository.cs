using System.Collections.Generic;
using System.Linq;
using Core;

public class TodoListRepository : ITodoListRepository
{
    private List<TodoList> _data = new List<TodoList>();

    public void Add(TodoList todoList)
    {
        _data.Add(todoList);
    }

    public IEnumerable<TodoList> GetAll()
    {
        return _data;
    }

    public void Update(TodoList todoList)
    {
        _data.RemoveAll(d => d.Id == todoList.Id);
        Add(todoList);
    }
}