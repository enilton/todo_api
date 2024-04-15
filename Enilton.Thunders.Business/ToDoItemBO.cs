using Enilton.Thunders.Models;
using Enilton.Thunders.Persistence;

namespace Enilton.Thunders.Business
{
    public class ToDoItemBO
    {
        private readonly IDBContext _context;

        public ToDoItemBO(IDBContext context)
        {
            _context = context;
        }

        public ToDoItem Create(ToDoItem toDoItem)
        {
            return (ToDoItem)_context.ToDoItems().Create(toDoItem);
        }

        public ToDoItem Delete(Guid id)
        {
            var existingItem = _context.ToDoItems().GetById(id);

            if (existingItem == null)
                throw new Exception("Item not found.");

            return _context.ToDoItems().Delete(id);
        }

        public ToDoItem Find(Guid Id)
        {
            return _context.ToDoItems().GetById(Id);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems().GetAll();
        }

        public ToDoItem Update(ToDoItem toDoItem)
        {
            return _context.ToDoItems().Update(toDoItem);
        }

    }
}
