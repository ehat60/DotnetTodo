using System;
using System.Collections.Generic;
using System.Linq;
using Core;

public class InMemoryTodoListRepository : ITodoListRepository
{
    private static List<TodoList> _data = new List<TodoList>();

    public void Add(TodoList todoList)
    {
        _data.Add(todoList);
    }

    public TodoList Get(Guid todoListId)
    {
        return _data.Single(d => d.Id == todoListId);
    }

    public IEnumerable<TodoList> GetAll()
    {
        return _data;
    }

    public TodoList GetByItemId(Guid itemId)
    {
        return _data.Single(d => d.Items.Any(i => i.Id == itemId));
    }

    public void Update(TodoList todoList)
    {
        _data.RemoveAll(d => d.Id == todoList.Id);
        Add(todoList);
    }
}