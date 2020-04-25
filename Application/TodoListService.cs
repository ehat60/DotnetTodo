using System;
using System.Collections.Generic;
using System.Linq;
using Core;

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
                .Select(ToViewModel);
        }

        public TodoListViewModel Add(TodoListCreateModel list)
        {
            var todoList = new Core.TodoList(list.Name);
            _todoListRepository.Add(todoList);
            return ToViewModel(todoList);
        }   

        public void AddItem(Guid todoListId, TodoItemCreateModel item)
        {
            var todoList = _todoListRepository.Get(todoListId);
            todoList.AddItem(new TodoItem(item.Name));
            _todoListRepository.Update(todoList);
        }

        public void ToggleItem(Guid itemId)
        {
            var todoList = _todoListRepository.GetByItemId(itemId);
            todoList.ToggleItem(itemId);
            _todoListRepository.Update(todoList);
        }

        public void RenameList(Guid todoListId, string name)
        {
            var todoList = _todoListRepository.Get(todoListId);
            todoList.Rename(name);
            _todoListRepository.Update(todoList);
        }

        private static TodoListViewModel ToViewModel(TodoList todoList)
        {
            return new TodoListViewModel
            {
                Id = todoList.Id,
                Name = todoList.Name,
                Items = todoList.Items.Select(i => new TodoListItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Checked = i.Checked
                }).ToList()
            };
        }
    }
}
