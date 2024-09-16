using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.EventStore;

namespace BlogAPI.Application.Queries
{
    public class GetPostByIdHandler
    {
        private readonly IEventStore _eventStore;

        public GetPostByIdHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public PostAggregate Handle(GetPostByIdQuery query)
        {
            var events = _eventStore.GetEvents(query.Id);
            var postAggregate = new PostAggregate(events);
            return postAggregate;
        }
    }
}
