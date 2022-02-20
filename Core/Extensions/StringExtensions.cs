using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToSha256(this string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public static bool IsValidMailAddress(this string emailaddress)
        {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(emailaddress).Success;
        }
        public static string FnReWriteTextForWeb(this string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            var result = text.ToLower();
            result = result.Replace("ş", "s");
            result = result.Replace("ı", "i");
            result = result.Replace("ü", "u");
            result = result.Replace("ç", "c");
            result = result.Replace("ğ", "g");
            result = result.Replace("ö", "o");
            result = result.Replace(" ", "-");
            result = result.Replace("  ", "-");
            result = result.Replace("   ", "-");
            result = result.Replace("' '", "");
            result = result.Replace("''", "");
            result = result.Replace("&", "");
            result = result.Replace("_", "");
            result = result.Replace("?", "");
            result = result.Replace("%", "");
            result = result.Replace("*", "");
            result = result.Replace("/", "");
            result = result.Replace("'", "");
            result = result.Replace(".", "");
            result = result.Replace("#", "");
            result = result.Replace("%", "");
            result = result.Replace("+", "_");
            result = result.Replace(")", "");
            result = result.Replace("(", "");
            result = result.Replace("^", "");
            result = result.Replace("'", "");
            result = result.Replace("\"", "");
            result = result.Replace("*", "");
            result = result.Replace("]", "");
            result = result.Replace("[", "");
            result = result.Replace("!", "");
            result = result.Replace("é", "");
            result = result.Replace("|", "");
            result = result.Replace("<", "");
            result = result.Replace(">", "");
            result = result.Replace("~", "");
            result = result.Replace(";", "");
            result = result.Replace(":", "");
            result = result.Replace("-----", "-");
            result = result.Replace("----", "-");
            result = result.Replace("---", "-");
            result = result.Replace("--", "-");
            return result;
        }
    }
}
