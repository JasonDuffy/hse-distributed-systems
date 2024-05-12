using Microsoft.AspNetCore.Mvc;
using TodoList_Backend.Model;
using TodoList_Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace TodoList_Backend.Controllers
{
    [ApiController]
    [Route("")]
    public class TodoListController : ControllerBase
    {
        /*
                private readonly ILogger<TodoListController> _logger;
                private readonly ITodoService _todoService;

                public TodoListController(ILogger<TodoListController> logger, ITodoService todoService)
                {
                    _logger = logger;
                    _todoService = todoService;
                }

                [HttpGet("todos")]
                [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
                public IActionResult GetTodos()
                {
                    var todos = _todoService.GetTodos();
                    _logger.LogInformation("Got todos: {todoList}", todos.ToList());
                    return Ok(todos);
                }

                [HttpPost("todos/{todo}")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                public IActionResult AddTodo([FromRoute] string todo)
                {
                    _logger.LogInformation("Adding todo: {todo}", todo);
                    _todoService.AddTodo(todo);
                    return Ok();
                }

                [HttpDelete("todos/{todo}")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                public IActionResult DeleteTodo([FromRoute] string todo)
                {
                    _logger.LogInformation("Deleting todo: {todo}", todo);
                    _todoService.DeleteTodo(todo);
                    return Ok();
                }
           */

        private readonly ApiDBContext _context;
        public TodoListController(ApiDBContext apiDBContext)
        {
            _context = apiDBContext;
        }


        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<string>>> GetTodoTitles()
        {
            var todoTitles = await _context.Todos.Select(todo => todo.Title).ToListAsync();
            return todoTitles;
        }

        [HttpPost("todos/{todo}")]
        public IActionResult AddTodo([FromBody] Todo value)
        {
            Model.Todo todo1 = new Model.Todo() { Title = value.Title };
            _context.Todos.Add(todo1);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("todos/{todo}")]
        public ActionResult<Todo> Delete(string todo)
        {
            var value = _context.Todos.FirstOrDefault(t => t.Title == todo);
            if (value == null)
            {
                return NotFound();
            }
            _context.Todos.Remove(value);
            _context.SaveChanges();
            return Ok();
        }
    }
}
