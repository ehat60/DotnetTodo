using System;
using System.Collections.Generic;

namespace Application
{
    public class TodoListService
    {
        public IEnumerable<TodoListViewModel> GetAll()
        {
            return new List<TodoListViewModel> {
                new TodoListViewModel {Navn = "Davzzzzzz"}
            };
        }
    }
}
