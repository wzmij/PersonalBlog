using System;
using Microsoft.Extensions.Caching.Memory;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Extenstions
{
    public static class CacheExtension
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDTO jtw)
            => cache.Set(GetJwtKey(tokenId), jtw, TimeSpan.FromSeconds(5));

        public static JwtDTO GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDTO>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}