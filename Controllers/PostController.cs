using Microsoft.AspNetCore.Mvc;
using Models;
using Config;
using Repository;

namespace Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController(ILogger<PostsController> logger, AppDbContext context) : ControllerBase
    {
        public readonly ILogger<PostsController> _logger = logger;
        public readonly PostRepository _postRepository = new(context);

        [HttpGet(Name = "GetPosts")]
        public IEnumerable<PostModel> GetAll()
        {
            return _postRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public ActionResult<PostModel> Get(string id)
        {
            PostModel? post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        [HttpPost("create", Name = "CreatePost")]
        public ActionResult<PostModel> Create(PostModel newPost)
        {
            _postRepository.Create(newPost);

            return CreatedAtAction(nameof(Get), new { id = newPost.Id }, newPost);
        }

        [HttpPut("{id}", Name = "UpdatePost")]
        public ActionResult<PostModel> Update(PostModel updatedPost, string id)
        {
            PostModel? post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            _postRepository.Update(post, updatedPost);

            return Accepted(post);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public ActionResult<PostModel> Delete(string id)
        {
            PostModel? post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            _postRepository.Delete(post);

            return Accepted(new { message = "post deleted" });
        }
    }
}