namespace PB.Infrastucture.Commands.Post
{
    public class CreatePost
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}