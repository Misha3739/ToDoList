using Foundation;

namespace ToDoList
{
    public class ToDoItem
    {
        [Export("important")]
        public bool IsImportant { get; set; }

        [Export("name")]
        public string Name { get; set; }

        public ToDoItem(){}

        public ToDoItem(string name, bool isImportant){
            this.Name = name;
            this.IsImportant = isImportant;
        }
    }
}