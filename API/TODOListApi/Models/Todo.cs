using System;
using System.ComponentModel.DataAnnotations;

namespace TODOListApi.Models
{
	public class Todo
	{
		[Key]
        public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Done { get; set; }
        public Todo()
		{
		}
	}
}

