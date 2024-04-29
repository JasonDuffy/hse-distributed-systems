using Microsoft.AspNetCore.Mvc;
using TodoList_Backend.Services;

namespace TodoList_Backend.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;
        private readonly ITodoService _todoService;

        public TodoListController(ILogger<TodoListController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        public IActionResult GetTodos()
        {
            var todos = _todoService.GetTodos();
            _logger.LogInformation("Got todos: {todoList}", todos.ToList());
            return Ok(todos);
        }

        [HttpPost("{todo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddTodo([FromRoute] string todo)
        {
            _logger.LogInformation("Adding todo: {todo}", todo);
            _todoService.AddTodo(todo);
            return Ok();
        }

        [HttpDelete("{todo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTodo([FromRoute] string todo)
        {
            _logger.LogInformation("Deleting todo: {todo}", todo);
            _todoService.DeleteTodo(todo);
            return Ok();
        }
    }
}
