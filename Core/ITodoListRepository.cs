using System.Collections.Generic;
using Core;

public interface ITodoListRepository
{
    IEnumerable<TodoList> GetAll();
    void Add(TodoList todoList);
    void Update(TodoList todoList);
}