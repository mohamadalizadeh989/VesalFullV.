using System.IO;

namespace VesalBahar.Core.Statics
{
    public static class PathTools
    {
        public static string ArticleImageDefautl = "/img/article/default-Article-image.png";
        public static string ArticleImagePath = "/upload/article/";
        public static string ArticleImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{ArticleImagePath}");

    }
}       