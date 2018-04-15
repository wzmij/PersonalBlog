namespace PB.Core.Models
{
    public class Post
    {
        public int Id { get; protected set; }
        public string Topic { get; protected set; }
        public string Body {get; protected set; }
        public Category Category { get; protected set; }
    }
}