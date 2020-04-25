using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class TodoListService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListService(ITodoListRepository todoListRepository)
        {
            this._todoListRepository = todoListRepository;
        }

        public IEnumerable<TodoListViewModel> GetAll()
        {
            return _todoListRepository.GetAll()
                .Select(t => new TodoListViewModel {
                    Id = t.Id,
                    Name = t.Name
                });
        }

        public void Add(TodoListCreateModel list)
        {
            _todoListRepository.Add(new Core.TodoList(list.Name));
        }
    }
}
