using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TODOListApi.Controllers;
using TODOListApi.Models;
using TODOListApi.Services;

namespace TodoListTest.Controllers
{
    public class TodoControllerUnitTest
	{
		private readonly Mock<ITodoService> _todoService;
		public TodoControllerUnitTest()
		{
			_todoService = new Mock<ITodoService>();
        }

        [Fact]
        public async void GetTodos_ReturnsOkResult()
        {
            //arrange
            var TodoList = GetTodosData();
            _todoService.Setup(service => service.GetTodos())
                .Returns(TodoList);

            var todoController = new TodoController(_todoService.Object);

            //act
            var todosResult = await todoController.GetTodos() as OkObjectResult;
            
            //assert
            Assert.NotNull(todosResult);
            Assert.Equal(StatusCodes.Status200OK, todosResult.StatusCode);
            var resultValue = Assert.IsType<List<Todo>>(todosResult.Value);
            Assert.Equal(TodoList.Count, resultValue.Count);

        }

        [Fact]
        public async void GetTodos_Returns500InternalServerError()
        {
            //arrange
            var TodoList = GetTodosData();
            _todoService.Setup(service => service.GetTodos())
                .Throws(new Exception());

            var todoController = new TodoController(_todoService.Object);

            //act
            var todosResult = await todoController.GetTodos();

            //assert
            var statusCodeResult = todosResult as ObjectResult;
            Assert.NotNull(statusCodeResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);

        }


        [Fact]
        public async Task GetTodoById_ReturnsNotFoundResult()
        {
            // arrange
            _todoService.Setup(service => service.GetTodo(It.IsAny<int>()))
                .Returns((Todo)null); 

            var todoController = new TodoController(_todoService.Object);

            // Act
            var todoResult = await todoController.GetTodo(1);

            // Assert
            Assert.NotNull(todoResult);
            Assert.IsType<NotFoundResult>(todoResult);
        }

        [Fact]
        public async Task GetTodoById_ReturnsTodo()
        {
            // arrange
            var todo = new Todo
            {
                Id = 1,
                Title = "Todo 1",
                Description = "Todo 1 desc ",
                Done = false,
            };

            _todoService.Setup(service => service.GetTodo(It.IsAny<int>()))
                .Returns(todo);

            var todoController = new TodoController(_todoService.Object);

            // Act
            var todoResult = await todoController.GetTodo(1) as OkObjectResult;

            // Assert
            Assert.NotNull(todoResult);
            Assert.Equal(StatusCodes.Status200OK, todoResult.StatusCode);

            var resultValue = Assert.IsType<Todo>(todoResult.Value);
            Assert.Equal(todo.Id, resultValue.Id);
        }


        private List<Todo> GetTodosData()
        {
            List<Todo> Todos = new List<Todo>
        {
            new Todo
            {
                Id = 1,
                Title = "Todo 1",
                Description = "Todo 1 desc ",
                Done = false,
            },
            new Todo
            {
                Id = 2,
                Title = "Todo 2",
                Description = "Todo 2 desc",
                Done = false,
            },
        };
            return Todos;
        }
    }
}

