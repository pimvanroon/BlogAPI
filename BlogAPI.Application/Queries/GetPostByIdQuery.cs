namespace BlogAPI.Application.Queries
{
    public class GetPostByIdQuery
    {
        public int Id { get; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }
}
