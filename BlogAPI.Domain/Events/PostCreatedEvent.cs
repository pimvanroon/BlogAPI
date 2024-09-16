namespace BlogAPI.Domain.Events
{
    public class PostCreatedEvent
    {
        public int Id { get; }
        public string Title { get; }
        public string Content { get; }
        public int AuthorId { get; }

        public PostCreatedEvent(int id, string title, string content, int authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorId = authorId;
        }
    }
}
