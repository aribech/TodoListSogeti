using Microsoft.AspNetCore.Mvc;
using TODOListApi.Models;
using TODOListApi.Services;

namespace TODOListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
		public TodoController(ITodoService todoService)
		{
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var todos = _todoService.GetTodos().OrderByDescending(t=>t.Id);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodo([FromRoute] int id)
        {
            try
            {
                var todo = _todoService.GetTodo(id);
                if (todo is not null)
                    return Ok(todo);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }



        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo todo)
        {
            try
            {
                var Todo = _todoService.InsertTodo(todo);
                return Ok(Todo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id,Todo todo)
        {
            try
            {
                var Todo = _todoService.UpdateTodo(id, todo);
                if (todo is null)
                    return NotFound();
                return Ok(Todo);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveTodo([FromRoute] int id)
        {
            try
            {
                var result = _todoService.DeleteTodo(id);
                if (result)
                    return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }

    
}

