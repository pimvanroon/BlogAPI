namespace BlogAPI.Domain.Entities
{
    public class Post
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int AuthorId { get; private set; }

        public Post(int id, string title, string content, int authorId)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorId = authorId;
        }

        public void UpdateContent(string content)
        {
            Content = content;
        }
    }
}
