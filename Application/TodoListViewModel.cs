using System;
using System.Collections.Generic;

public class TodoListViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<TodoListItemViewModel> Items { get; set; }
}

public class TodoListItemViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Checked { get; set; }
}