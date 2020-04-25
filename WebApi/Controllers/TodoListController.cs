using System.Collections.Generic;
using Application;
using Microsoft.AspNetCore.Mvc;

public class TodoListController : ControllerBase
{
    private readonly TodoListService _todoListService;

    public TodoListController(TodoListService todoListService)
    {
        this._todoListService = todoListService;
    }

    /// <summary>
    /// Gets all todo lists
    /// </summary>
    [HttpGet("/todoList")]
    public IEnumerable<TodoListViewModel> GetAll()
    {
        return _todoListService.GetAll();
    }

    /// <summary>
    /// Creates a new todo list
    /// </summary>
    [HttpPost("/todoList")]
    public TodoListViewModel CreateList([FromBody] TodoListCreateModel list)
    {
        return _todoListService.Add(list);
    }

    /// <summary>
    /// Adds a todo item to a todo list
    /// </summary>
    [HttpPost("/todoList/{todoListId}/addItem")]
    public void AddItem([FromBody] TodoItemCreateModel item, [FromRoute] System.Guid todoListId)
    {
        _todoListService.AddItem(todoListId, item);
    }

    /// <summary>
    /// Renames a todo list
    /// </summary>
    [HttpPut("/todoList/{todoListId}/rename")]
    public void RenameList([FromQuery] string name, [FromRoute] System.Guid todoListId)
    {
        _todoListService.RenameList(todoListId, name);
    }
}

