namespace BrightSky.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveFirst(this string str, int number)
        {
            if (string.IsNullOrEmpty(str) || number > str.Length || number < 0) return string.Empty;

            return str.Substring(number);
        }

        public static string RemoveFirstCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            return str.RemoveFirst(1);
        }

        public static string RemoveLast(this string str, int number)
        {
            if (string.IsNullOrEmpty(str) || number > str.Length || number < 0) return string.Empty;

            return str.Substring(0, str.Length - number);
        }

        public static string RemoveLastCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return str.RemoveLast(1);
        }
    }
}