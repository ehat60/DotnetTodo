using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async System.Threading.Tasks.Task Test1Async()
        {            
            var client = _factory.CreateClient();

            var createResp = await client.PostAsJsonAsync("todoList", new TodoListCreateModel{Name = "test"});
            var response = await client.GetAsync("todoList");
            var todoLists = await response.Content.ReadAsAsync<IEnumerable<TodoListViewModel>>();
            
            Assert.Equal(1, todoLists.Count());
  
        }
    }

    public class TodoListCreateModel
    {
        public string Name { get; set; }
    }

    public class TodoListViewModel
    {
        public Guid Id { get; set; }
        public string Navn { get; set; }
    }
}
