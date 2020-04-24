using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class TodoList
    {
        private List<TodoItem> _items = new List<TodoItem>();
        public TodoList(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TodoItem> Items => _items;

        public void AddItem(TodoItem item)
        {
            if (Items.Any(i => i.Name == item.Name))
            {
                throw new Exception($"Item with name {item.Name} already exists");
            }

            _items.Add(item);
        }
    }
}
