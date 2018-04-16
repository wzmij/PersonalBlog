using System;

namespace PB.Infrastucture.Extenstions
{
    public static class StringExtenstions
    {
        public static bool Empty(this string value)
            => String.IsNullOrWhiteSpace(value);
    }
}