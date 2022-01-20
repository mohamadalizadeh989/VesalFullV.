using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VesalBahar.Core.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string Fixed(this string input)
        {
            return input.Trim().ToLower();
        }
        public static string FixedUrl(this string url)
        {
            url = url.Trim();
            if (url == null)
            {
                throw new NullReferenceException("title that your want sort it is null");
            }

            if (Regex.IsMatch(url, @"^[\u0600-\u06FF]+$"))
            {
                return url.Replace(" ", "-");
            }
            var regex = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            var text = regex.Replace(url, "-");
            return text.Replace(" ", "-").ToLower()
                .Replace(".", "")
                .Replace("--", "-")
                .Replace("_", "-")
                .Replace("-_", "-")
                .Replace(".", "-")
                .Replace("+", "-")
                .Replace("  ", "-")
                .Replace("__", "-")
                .Replace("*", "")
                .Replace(@"\", "-")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("--", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string ToToman(this int amount)
        {
            return $"{amount:#,# تومان}";
        }
    }
}
