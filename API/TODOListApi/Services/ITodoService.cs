using System;
using TODOListApi.Models;

namespace TODOListApi.Services
{
	public interface ITodoService
	{
        bool DeleteTodo(int id);
        Todo GetTodo(int id);
        IEnumerable<Todo> GetTodos();
        Todo InsertTodo(Todo todo);
        Todo UpdateTodo(int id, Todo todo);
    }
}

