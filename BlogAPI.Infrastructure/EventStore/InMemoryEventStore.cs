using System.Collections.Generic;

namespace BlogAPI.Infrastructure.EventStore
{
    public interface IEventStore
    {
        void SaveEvent<T>(T @event);
        IEnumerable<object> GetEvents(int entityId);
    }

    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<int, List<object>> _events = new();

        public void SaveEvent<T>(T @event)
        {
            var entityId = (int)@event.GetType().GetProperty("Id").GetValue(@event);
            if (!_events.ContainsKey(entityId))
            {
                _events[entityId] = new List<object>();
            }
            _events[entityId].Add(@event);
        }

        public IEnumerable<object> GetEvents(int entityId)
        {
            return _events.ContainsKey(entityId) ? _events[entityId] : new List<object>();
        }
    }
}
