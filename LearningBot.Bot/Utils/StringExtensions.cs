using LearningBot.Bot.Constants;
using System.Text.RegularExpressions;

namespace LearningBot.Bot.Utils;

internal static class StringExtensions
{
    private const string EmailRegex = @"^\w+@\w+\.\w+$";

    public static bool IsValidEmail(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, EmailRegex);
    }

    public static bool IsCommand(this string input)
    {
        return input.StartsWith(Commands.CommandStartSymbol);
    }
}
