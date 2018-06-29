using System;
using System.Threading.Tasks;
using PB.Core.Models;

namespace PB.Infrastucture.Services
{
    public interface IPostService
    {
         Task Create(string header, string body, int categoryId, Guid userId);
    }
}