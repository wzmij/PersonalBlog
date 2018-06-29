using System;

namespace PB.Core.Models
{
    public class Category
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public Category(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw(new Exception("Category name can't be empty"));
            }

            //regex

            Name = name;
        }
    }
}