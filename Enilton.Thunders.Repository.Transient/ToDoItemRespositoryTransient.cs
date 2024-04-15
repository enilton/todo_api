using Enilton.Thunders.Models;
using Enilton.Thunders.Persistence;
using System.Security.AccessControl;

namespace Enilton.Thunders.Persistence.Transient
{
    internal class ToDoItemRespositoryTransient : IToDoItemPersistence
    {
        private IList<ToDoItem> _toDoItems;

        public ToDoItemRespositoryTransient()
        {
            if (_toDoItems == null)
                _toDoItems = new List<ToDoItem>();
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _toDoItems.Where(i => i.DeletedAt == DateTime.MinValue) ?? Enumerable.Empty<ToDoItem>();
        }

        public ToDoItem? GetById(Guid toDoItemID)
        {
            return _toDoItems?.Where(i => i.Id == toDoItemID && i.DeletedAt == DateTime.MinValue).FirstOrDefault();

        }

        public ToDoItem Update(ToDoItem toDoItem)
        {
            var existingItem = _toDoItems.Where(i => i.Id == toDoItem.Id).FirstOrDefault();

            if (existingItem == null)
                throw new Exception("ToDoItem not found.");

            _toDoItems.Remove(existingItem);

            existingItem = toDoItem;

            _toDoItems.Add(toDoItem);

            return toDoItem;
        }

        public ToDoItem Delete(Guid toDoItemID)
        {
            var toDoItem = _toDoItems.Where(i => i.Id == toDoItemID).FirstOrDefault();

            if (toDoItem == null)
                throw new Exception("ToDoItem not found.");

            _toDoItems.Remove(toDoItem);

            toDoItem.DeletedAt = DateTime.Now;

            _toDoItems.Add(toDoItem);

            return toDoItem;
        }

        ToDoItem IToDoItemPersistence.Create(ToDoItem toDoItem)
        {
            _toDoItems.Add(toDoItem);
            return toDoItem;
        }
    }
}
