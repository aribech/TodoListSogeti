using System;
using TODOListApi.Models;
using TODOListApi.Data;

namespace TODOListApi.Services
{
	public class TodoService : ITodoService
	{
        private readonly TodoContext _todoContext;
		public TodoService(TodoContext todoContext)
		{
            _todoContext = todoContext;

        }

        public bool DeleteTodo(int id)
        {
            var todo = _todoContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
                return false;
            var result = _todoContext.Todos.Remove(todo);
            _todoContext.SaveChanges();
            return result ==null ? false : true;
        }

        public Todo GetTodo(int id)
        {
            return _todoContext.Todos.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _todoContext.Todos;
        }

        public Todo InsertTodo(Todo todo)
        {
            var result = _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();
            return result.Entity;
        }

        public Todo UpdateTodo(int id, Todo todo)
        {
            var result = _todoContext.Todos.Update(todo);
            _todoContext.SaveChanges();
            return result.Entity;
        }

    }
}

