using BlogAPI.Application.Commands;
using BlogAPI.Application.Queries;
using BlogAPI.Domain.Entities;
using BlogAPI.Domain.Events;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class PostControllerTests
{
    private readonly Mock<CreatePostHandler> _createPostHandlerMock;
    private readonly Mock<GetPostByIdHandler> _getPostByIdHandlerMock;
    private readonly PostController _controller;

    public PostControllerTests()
    {
        _createPostHandlerMock = new Mock<CreatePostHandler>();
        _getPostByIdHandlerMock = new Mock<GetPostByIdHandler>();
        _controller = new PostController(_createPostHandlerMock.Object, _getPostByIdHandlerMock.Object);
    }

    [Fact]
    public void CreatePost_ReturnsCreated_WhenCommandIsHandled()
    {
        var createCommand = new CreatePostCommand("Test Title", "Test Content", 1);
        _createPostHandlerMock.Setup(x => x.Handle(createCommand)).Returns(/* appropriate result */);

        var result = _controller.CreatePost(createCommand);

        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public void GetPostById_ReturnsOk_WhenPostIsFound()
    {
        var postAggregate = new PostAggregate(new List<object>
        {
            new PostCreatedEvent(1, "Title", "Content", 1)
        });
        _getPostByIdHandlerMock.Setup(x => x.Handle(It.IsAny<GetPostByIdQuery>())).Returns(postAggregate);

        var result = _controller.GetPostById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var post = Assert.IsType<Post>(okResult.Value);
        Assert.Equal("Title", post.Title);
    }

    [Fact]
    public void GetPostById_ReturnsNotFound_WhenPostIsNotFound()
    {
        _getPostByIdHandlerMock.Setup(x => x.Handle(It.IsAny<GetPostByIdQuery>())).Returns(new PostAggregate(new List<object>()));

        var result = _controller.GetPostById(1);

        Assert.IsType<NotFoundResult>(result);
    }
}
