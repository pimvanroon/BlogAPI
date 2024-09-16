namespace BlogAPI.Domain.Events
{
    public class PostUpdatedEvent
    {
        public int Id { get; }
        public string Content { get; }

        public PostUpdatedEvent(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
