namespace Layman
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class should
    {
        public static bool throw_a<T>(Action act)
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

        public static bool not_throw<T>(Action act)
        {
            return !throw_a<T>(act);
        }

        public static bool throw_an_exception(Action act)
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

        public static bool not_throw_an_exception(Action act)
        {
            return !throw_an_exception(act);
        }
    }

    public static class ShouldExtension
    {
        public static bool should_be<T>(this T actual, T expected)
        {
            return EqualityComparer<T>.Default.Equals(actual, expected);
        }

        /*
        public static bool should_be(this object actual, string expected)
        {
            return expected.Equals(actual);
        }
        */

        public static bool should_not_be<T>(this T actual, T unexpected)
        {
            return !unexpected.should_be(actual);
        }

        /*
        public static bool should_not_be(this object actual, string unexpected)
        {
            return !unexpected.should_be(actual);
        }
        */

        public static bool should_match(this object value, string regex)
        {
            return value != null && new Regex(regex).IsMatch(value.ToString());
        }

        public static bool is_a(this object tested, Func<object, bool> check)
        {
            return check(tested);
        }
    }
}
