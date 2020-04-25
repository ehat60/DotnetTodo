using System;
using Application;
using Microsoft.AspNetCore.Mvc;

public class TodoItemController : ControllerBase
{
    private readonly TodoListService _todoListService;

    public TodoItemController(TodoListService todoListService)
    {
        this._todoListService = todoListService;
    }

    /// <summary>
    /// Toggles an item
    /// </summary>
    [HttpPost("/todoItem/toggle")]
    public void Toggle(Guid id)
    {
        _todoListService.ToggleItem(id);
    }
}