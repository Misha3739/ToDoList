using Foundation;

namespace ToDoList
{
    public class ToDoItem
    {
        [Export("important")]
        public bool IsImportant { get; set; }

        [Export("name")]
        public string Name { get; set; }
    }
}