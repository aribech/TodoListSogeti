using System;
using Microsoft.EntityFrameworkCore;
using TODOListApi.Models;

namespace TODOListApi.Data
{
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions options) : base(options)
		{
            Database.EnsureCreated(); 
            if (!Todos.Any())
            {
                var fakeTodos = TodoListDataInit.GenerateFakeTodos(4);
                Todos.AddRange(fakeTodos);
                SaveChanges();
            }
        }

        public DbSet<Todo> Todos { get; set; }

        
    }
}

