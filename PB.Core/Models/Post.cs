using System;
using System.Collections.Generic;

namespace PB.Core.Models
{
    public class Post
    {
        public int Id { get; protected set; }
        public string Header { get; protected set; }
        public string Body {get; protected set; }
        public int CategoryId { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Post(string header, string body, User user, Category categories)
        {
            SetHeader(header);
            SetBody(body);
            UserId = user.Id;
            CategoryId = categories.Id;
            CreatedAt = DateTime.Now;            
        }

        public void SetHeader(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw(new Exception("Post header can't be empty"));
            }

            //Add Settings
            if (text.Length > 50)
            {
                throw(new Exception("Post header is too long. Max value: "));
            }

            Header = text;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetBody(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw(new Exception("Post body can't be empty"));
            }

            Body = text;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}