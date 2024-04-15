using Enilton.Thunders.Models;
using Xunit;

namespace Enilton.Thunders.Tests.Models
{
    public class ToDoItemTests
    {
        [Fact]
        public void NewObjectHasId()
        {
            var newToDoItem = new ToDoItem("title", "content");

            Assert.NotEqual(new Guid(), newToDoItem.Id);
        }
    }
}