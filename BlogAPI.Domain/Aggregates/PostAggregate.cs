using BlogAPI.Domain.Events;
using System.Collections.Generic;

namespace BlogAPI.Domain.Entities
{
    public class PostAggregate
    {
        public Post Post { get; private set; }

        public PostAggregate(IEnumerable<object> events)
        {
            foreach (var @event in events)
            {
                Apply(@event);
            }
        }

        // Rebuild the Post entity by applying the events.
        private void Apply(object @event)
        {
            switch (@event)
            {
                case PostCreatedEvent createdEvent:
                    Post = new Post(createdEvent.Id, createdEvent.Title, createdEvent.Content, createdEvent.AuthorId);
                    break;
                case PostUpdatedEvent updatedEvent:
                    Post.UpdateContent(updatedEvent.Content);
                    break;
            }
        }
    }
}
