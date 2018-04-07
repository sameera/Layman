namespace Layman
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class ShouldExtension
    {
        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_be<T>(this T actual, T expected)
        {
            return EqualityComparer<T>.Default.Equals(actual, expected);
        }

        /*
        public static bool should_be(this object actual, string expected)
        {
            return expected.Equals(actual);
        }
        */

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_not_be<T>(this T actual, T unexpected)
        {
            return !unexpected.Should_be(actual);
        }

        /*
        public static bool should_not_be(this object actual, string unexpected)
        {
            return !unexpected.should_be(actual);
        }
        */

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_match(this object value, string regex)
        {
            return value != null && new Regex(regex).IsMatch(value.ToString());
        }

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Is_a(this object tested, Func<object, bool> check)
        {
            return check(tested);
        }
    }
}
