using Enilton.Thunders.Business;
using Enilton.Thunders.Models;
using Enilton.Thunders.Persistence;
using Enilton.Thunders.Repository;
using Enilton.Thunders.Repository.Transient;
using Moq;
using Xunit;

namespace Enilton.Thunders.Tests.Business
{
    public class ToDoItemBOTests
    {
        [Fact]
        public void WhenCreate()
        {
            var newToDoItem = new ToDoItem("title", "content");

            var contextMock = DbContext.GetTransientContext();

            Assert.NotNull(new ToDoItemBO(contextMock).Create(newToDoItem));
        }

        [Fact]
        public void WhenGetAll()
        {
            var newToDoItem = new ToDoItem("title", "content");

            var contextMock = DbContext.GetTransientContext();

            var toDoItemBO = new ToDoItemBO(contextMock);

            toDoItemBO.Create(newToDoItem);

            Assert.NotNull(toDoItemBO.GetAll());
            Assert.Single(toDoItemBO.GetAll());
        }

        [Fact]
        public void WhenDelete()
        {
            var newToDoItem = new ToDoItem("title", "content");

            var contextMock = DbContext.GetTransientContext();

            var toDoItemBO = new ToDoItemBO(contextMock);

            toDoItemBO.Create(newToDoItem);

            toDoItemBO.Delete(newToDoItem.Id);

            Assert.Empty(toDoItemBO.GetAll());
        }

        [Fact]
        public void WhenUpdate()
        {
            var newToDoItem = new ToDoItem("title", "content");

            var contextMock = DbContext.GetTransientContext();

            var toDoItemBO = new ToDoItemBO(contextMock);

            toDoItemBO.Create(newToDoItem);

            newToDoItem.Title = "title2";
            newToDoItem.Content = "content2";

            toDoItemBO.Update(newToDoItem);

            var updatedObject = toDoItemBO.Find(newToDoItem.Id);

            Assert.Equal(updatedObject.Title, newToDoItem.Title);
            Assert.Equal(updatedObject.Content, newToDoItem.Content);
        }



        [Fact]
        public void WhenGetOne()
        {
            var newToDoItem = new ToDoItem("title", "content");

            var contextMock = DbContext.GetTransientContext();

            var toDoItemBO = new ToDoItemBO(contextMock);

            toDoItemBO.Create(newToDoItem);

            Assert.NotNull(toDoItemBO.Find(newToDoItem.Id));
        }
    }
}