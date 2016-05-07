using System.Linq;
using System.Text.RegularExpressions;

namespace ClassGenerator.Host
{
    public static class Helper
    {
        private static Regex ReplaceTo_ = new Regex("[-/]+", RegexOptions.Compiled); //two symbols '-' and '/'
        private static Regex ReplaceToEmpty = new Regex("\\W+", RegexOptions.Compiled); //Symbols not for Name
        private static Regex LeadingNumbers = new Regex("\\A[0-9]+", RegexOptions.Compiled); //Leading Numbers

        private static string MoveDigitsFromHeadToTail(string text)
        {
            var Match = LeadingNumbers.Match(text);
            if (Match.Length == 0) return text;
            else return text.Substring(Match.Length) + "_" + Match.Value;
        }

        internal static string StartWithUpperCase(string text)
        {
            if (text.Length < 2) return text.ToUpper();
            else return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }

        public static string ConvertToValidCSName(string text)
        {
            return StartWithUpperCase(MoveDigitsFromHeadToTail(ReplaceChars(text.Split('.').Last())));
        }



        private static string ReplaceChars(string text)
        {
            return ReplaceToEmpty.Replace(ReplaceTo_.Replace(text, "_").Replace("=", "Equal"), string.Empty);
        }
    }
}