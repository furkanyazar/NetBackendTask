using System.Text.RegularExpressions;

namespace Core.Extensions;

public static class StringExtensions
{
    public static string ToEnglishCase(this string arg)
    {
        char[] turkishChars =  { 'ç', 'ğ', 'ı', 'ö', 'ş', 'ü', 'Ç', 'Ğ', 'İ', 'Ö', 'Ş', 'Ü' },
            englishChars =  { 'c', 'g', 'i', 'o', 's', 'u', 'C', 'G', 'I', 'O', 'S', 'U' };

        for (int i = 0; i < turkishChars.Length; i++)
            arg = arg.Replace(turkishChars[i], englishChars[i]);

        return arg;
    }

    public static string ToValueCase(this string arg)
    {
        string result = arg.ToLower().ToEnglishCase();
        result = Regex.Replace(result, @"[^0-9a-zA-Z:\s]+", "");
        result = Regex.Replace(result, @"\s+", " ");
        result = result.Replace(" ", "-").Trim();
        return result;
    }
}
