
using Enilton.Thunders.Business;
using Enilton.Thunders.Models;
using Enilton.Thunders.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Enilton.Thunders.API.Controllers
{
    [ApiController]
    [Route("api/todolist")]
    public class ToDoItemController : ControllerBase
    {
        private readonly ILogger<ToDoItemController> _logger;
        private readonly ToDoItemBO _toDoItemBO;

        public ToDoItemController(ILogger<ToDoItemController> logger, IDBContext context)
        {
            _logger = logger;
            _toDoItemBO = new ToDoItemBO(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_toDoItemBO.GetAll());
        }

        [HttpGet("{todoitemid}")]
        public IActionResult Find(string todoitemid)
        {
            return Ok(_toDoItemBO.Find(Guid.Parse(todoitemid)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ToDoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ToDoItem toDoItem)
        {
            return Ok(_toDoItemBO.Create(toDoItem));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ToDoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST: VendedorController/Create
        public ActionResult Update([FromBody] ToDoItem toDoItem)
        {
            return Ok(_toDoItemBO.Update(toDoItem));
        }

        [HttpDelete("{todoitemid}")]
        [ProducesResponseType(typeof(ToDoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST: VendedorController/Create
        public ActionResult Delete(string todoitemid)
        {
            return Ok(_toDoItemBO.Delete(Guid.Parse(todoitemid)));
        }
    }
}
