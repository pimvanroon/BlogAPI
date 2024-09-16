using BlogAPI.Application.Commands;
using BlogAPI.Application.Queries;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly CreatePostHandler _createPostHandler;
    private readonly GetPostByIdHandler _getPostByIdHandler;

    public PostController(CreatePostHandler createPostHandler, GetPostByIdHandler getPostByIdHandler)
    {
        _createPostHandler = createPostHandler;
        _getPostByIdHandler = getPostByIdHandler;
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreatePostCommand command)
    {
        // Use the CreatePostHandler for creating a new post
        _createPostHandler.Handle(command);
        return CreatedAtAction(nameof(GetPostById), new { id = command.AuthorId }, command);
    }

    [HttpGet("{id}")]
    public IActionResult GetPostById(int id)
    {
        // Use the GetPostByIdHandler for fetching a post by ID
        var postAggregate = _getPostByIdHandler.Handle(new GetPostByIdQuery(id));
        if (postAggregate.Post == null)
        {
            return NotFound();
        }
        return Ok(postAggregate.Post);
    }
}
