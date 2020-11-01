namespace AlertToCare.Utility
{
    public static class Utils
    {
        public static bool IsValueNull(object value)
        {
            return (value == null);
        }
        public static bool IsLengthValid(string word, int length)
        {
            return word.Length == length;
        }
    }
}
