using System.Collections.Generic;

namespace PB.Core.Models
{
    public class UsersPosts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Post> Posts { get; set; }
    }
}