using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class TodoListTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public TodoListTests(CustomWebApplicationFactory factory)
        {
            this._factory = factory;
        }

        [Fact]
        public async System.Threading.Tasks.Task CanCreateList()
        {
            var client = _factory.CreateClient();

            var name = Guid.NewGuid().ToString();
            var createResp = await client.PostAsJsonAsync("todoList", new TodoListCreateModel { Name = name });
            var createdList = await createResp.Content.ReadAsAsync<TodoListViewModel>();
            var response = await client.GetAsync("todoList");
            var todoLists = await response.Content.ReadAsAsync<IEnumerable<TodoListViewModel>>();

            Assert.Equal(name, todoLists.Single(t => t.Id == createdList.Id).Name);
        }

        [Fact]
        public async System.Threading.Tasks.Task CanAddItemToList()
        {
            var client = _factory.CreateClient();
            var createdList = await CreateList(client);

            var itemName = Guid.NewGuid().ToString();
            await client.PostAsJsonAsync($"/todoList/{createdList.Id}/addItem", new TodoListItemViewModel { Name = itemName });

            var response = await client.GetAsync("todoList");
            var todoLists = await response.Content.ReadAsAsync<IEnumerable<TodoListViewModel>>();

            Assert.Equal(itemName, todoLists.Single(t => t.Id == createdList.Id).Items.Single(i => i.Name == itemName).Name);
        }

        [Fact]
        public async System.Threading.Tasks.Task CanRenameList()
        {
            var client = _factory.CreateClient();

            var createdList = await CreateList(client);

            var newName = Guid.NewGuid().ToString();
            await client.PutAsync($"/todoList/{createdList.Id}/rename?name={newName}", null);

            var response = await client.GetAsync("todoList");
            var todoLists = await response.Content.ReadAsAsync<IEnumerable<TodoListViewModel>>();

            Assert.Equal(newName, todoLists.Single(t => t.Id == createdList.Id).Name);
        }

        private static async Task<TodoListViewModel> CreateList(HttpClient client)
        {
            var createResp = await client.PostAsJsonAsync("todoList", new TodoListCreateModel { Name = "test" });
            var createdList = await createResp.Content.ReadAsAsync<TodoListViewModel>();
            return createdList;
        }
    }

    public class TodoListCreateModel
    {
        public string Name { get; set; }
    }

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
}
