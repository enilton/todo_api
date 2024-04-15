using Enilton.Thunders.Persistence;
using Enilton.Thunders.Persistence.Transient;

namespace Enilton.Thunders.Repository.Transient
{
    public class DbContext : IDBContext
    {       
        private readonly IToDoItemPersistence _toDoItemRepository;

        public DbContext()
        {
            if(_toDoItemRepository == null)
                _toDoItemRepository = new ToDoItemRespositoryTransient();
        }

        public static DbContext GetTransientContext()
        {
            return new DbContext();
        }

        public IToDoItemPersistence ToDoItems()
        {
            if (_toDoItemRepository == null)
                throw new Exception("Connection is closed.");

            return _toDoItemRepository;
        }
        

    }
}
