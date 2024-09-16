using BlogAPI.Infrastructure.EventStore;
using Xunit;
using System.Collections.Generic;
using BlogAPI.Domain.Events;

public class InMemoryEventStoreTests
{
    private readonly InMemoryEventStore _eventStore;

    public InMemoryEventStoreTests()
    {
        _eventStore = new InMemoryEventStore();
    }

    [Fact]
    public void SaveEvent_AddsEvent_ToEventStore()
    {
        // Arrange
        var postCreatedEvent = new PostCreatedEvent(1, "Title", "Content", 1);

        // Act
        _eventStore.SaveEvent(postCreatedEvent);

        // Assert
        var events = _eventStore.GetEvents(1);
        Assert.Contains(postCreatedEvent, events);
    }

    [Fact]
    public void GetEvents_ReturnsEmpty_WhenNoEventsExist()
    {
        // Act
        var events = _eventStore.GetEvents(1);

        // Assert
        Assert.Empty(events);
    }
}
