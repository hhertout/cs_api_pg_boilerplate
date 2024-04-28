using Config;
using Models;

namespace Repository
{
    public class PostRepository(AppDbContext context)
    {
        public readonly AppDbContext _db = context;

        public IEnumerable<PostModel> GetAll()
        {
            return _db.Posts;
        }

        public PostModel? GetById(string id)
        {
            return _db.Posts.Find(id);
        }

        public PostModel? GetByName(string name)
        {
            return _db.Posts.FirstOrDefault(post => post.Name == name);
        }

        public void Create(PostModel newPost)
        {
            _db.Posts.Add(newPost);
            _db.SaveChanges();
        }

        public void Update(PostModel oldPost, PostModel updatedPost)
        {
            oldPost.Name = updatedPost.Name;
            oldPost.Description = updatedPost.Description;

            _db.Posts.Update(oldPost);
            _db.SaveChanges();
        }

        public void Delete(PostModel post)
        {
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }
    }
}