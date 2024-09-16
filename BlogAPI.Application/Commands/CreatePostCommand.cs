namespace BlogAPI.Application.Commands
{
    public class CreatePostCommand
    {
        public string Title { get; }
        public string Content { get; }
        public int AuthorId { get; }

        public CreatePostCommand(string title, string content, int authorId)
        {
            Title = title;
            Content = content;
            AuthorId = authorId;
        }
    }
}
