namespace Layman
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Should
    {
        public static bool Throw_a<T>(Action act)
        {
            try
            {
                act();
                return false;
            }
            catch (Exception ex)
            {
                return ex is T;
            }
        }

        public static bool Not_throw<T>(Action act) => !Throw_a<T>(act);

        public static bool Throw_an_exception(Action act)
        {
            try
            {
                act();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static bool Not_throw_an_exception(Action act) => !Throw_an_exception(act);
    }

    public static class ShouldExtension
    {
        public static bool Should_be<T>(this T actual, T expected) => EqualityComparer<T>.Default.Equals(actual, expected);
        
        public static bool Should_not_be<T>(this T actual, T unexpected) => !unexpected.Should_be(actual);

        public static bool Should_match(this object value, string regex) => value != null && new Regex(regex).IsMatch(value.ToString());

        public static bool Is_a(this object tested, Func<object, bool> check) => check(tested);
    }
}
