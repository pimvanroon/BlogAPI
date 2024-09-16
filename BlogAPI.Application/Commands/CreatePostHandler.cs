using BlogAPI.Domain.Entities;
using BlogAPI.Domain.Events;
using BlogAPI.Infrastructure.EventStore;

namespace BlogAPI.Application.Commands
{
    public class CreatePostHandler
    {
        private readonly IEventStore _eventStore;

        public CreatePostHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Handle(CreatePostCommand command)
        {
            var postCreatedEvent = new PostCreatedEvent(0, command.Title, command.Content, command.AuthorId);
            _eventStore.SaveEvent(postCreatedEvent);
        }
    }
}
