using System;
using System.Collections.Generic;
using TODOListApi.Models;
using Bogus;

namespace TODOListApi.Data
{
	public static class TodoListDataInit
    {
        public static List<Todo> GenerateFakeTodos(int count)
        {
            var faker = new Faker<Todo>()
                .RuleFor(t => t.Title, f => f.Random.Word())
                .RuleFor(t => t.Description, f => f.Random.Words(5))
                .RuleFor(t => t.Done, f => f.Random.Bool());

            return faker.Generate(count);
        }
    }
}

