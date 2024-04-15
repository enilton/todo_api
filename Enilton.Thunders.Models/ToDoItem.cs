namespace Enilton.Thunders.Models
{
    public class ToDoItem : ModelBase
    { 
        public string? Title { get; set; }

        public string? Content { get; set; }        

        public ToDoItem(string title, string content)
        {         
            Title = title;
            Content = content;            
        }

        public ToDoItem() { }
        
    }
}
