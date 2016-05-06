using System.Linq;
using System.Text.RegularExpressions;

namespace ClassGenerator.Host
{
    public static class Helper
    {
        private static string MoveDigitsFromHeadToTail(string text)
        {
            var numbPrefix = text.TakeWhile(c => char.IsDigit(c));
            int DigitsCount = numbPrefix.Count();
            if (DigitsCount == 0) return text;
            else return text.Substring(DigitsCount) + "_" + new string(numbPrefix.ToArray());
        }

        internal static string StartWithUpperCase(string text)
        {
            if (text.Length < 2) return text.ToUpper();
            else return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }

        public static string ConvertToValidCSName(string text)
        {
            return StartWithUpperCase(MoveDigitsFromHeadToTail(ReplaceChars(text)));
        }

        private static Regex ReplaceTo_ = new Regex("[-/]+", RegexOptions.Compiled); //two symbols '-' and '/'
        private static Regex ReplaceToEmpty = new Regex("\\W+", RegexOptions.Compiled); //Symbols not for Name

        private static string ReplaceChars(string text)
        {
            return ReplaceToEmpty.Replace(ReplaceTo_.Replace(text.Split('.').Last(), "_").Replace("=", "Equal"), string.Empty);
        }
    }
}