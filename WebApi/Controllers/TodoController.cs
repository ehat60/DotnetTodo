using System.Collections.Generic;
using Application;
using Microsoft.AspNetCore.Mvc;

public class TodoController : ControllerBase
{
    private readonly TodoListService _todoListService;

    public TodoController(TodoListService todoListService)
    {
        this._todoListService = todoListService;
    }

    [HttpGet("/todoList")]
    public IEnumerable<TodoListViewModel> GetAll()
    {
        return _todoListService.GetAll();
    }

    [HttpPost("/todoList")]
    public void Add(TodoListCreateModel list)
    {
        _todoListService.Add(list);
    }
}