using System;
using System.Text.RegularExpressions;

namespace rassler.frontend.core.Domain.Utilities.Regex
{
    public class Validator
    {
        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, Expressions.PhoneNumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool IsDayValid(string day)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(day, Expressions.DayRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, Expressions.EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool IsPasswordValid(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, Expressions.PasswordRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
