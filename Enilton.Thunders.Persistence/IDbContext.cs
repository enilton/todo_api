using Enilton.Thunders.Persistence;

namespace Enilton.Thunders.Persistence
{
    public interface IDBContext
    {
        IToDoItemPersistence ToDoItems();
    }
}
