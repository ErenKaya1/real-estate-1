namespace RealEstate.Common.Functions.Extensions
{
    public static class StringExtensions
    {
        public static string ToSlug(this string value)
        {
            return value.TrimEnd()
                        .TrimStart()
                        .ToLower()
                        .Replace('ü', 'u')
                        .Replace('ö', 'o')
                        .Replace('ı', 'i')
                        .Replace('ş', 's')
                        .Replace('ç', 'c')
                        .Replace('ğ', 'g')
                        .Replace(' ', '-')
                        .Replace('/', '-');
        }
    }
}