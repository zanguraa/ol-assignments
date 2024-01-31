namespace Classroom.TodoWithAuth
{
    public class TodoModel
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public Boolean IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
