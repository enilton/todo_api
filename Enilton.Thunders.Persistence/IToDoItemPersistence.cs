using Enilton.Thunders.Models;

namespace Enilton.Thunders.Persistence
{
    public interface IToDoItemPersistence
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(Guid toDoItemID);
        ToDoItem Create(ToDoItem toDoItem);
        ToDoItem Update(ToDoItem toDoItem);
        ToDoItem Delete(Guid toDoItemID);
    }
}
