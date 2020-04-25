using System;
using System.Collections.Generic;
using Core;

public interface ITodoListRepository
{
    IEnumerable<TodoList> GetAll();
    void Add(TodoList todoList);
    void Update(TodoList todoList);
    TodoList Get(Guid todoListId);
    TodoList GetByItemId(Guid itemId);
}