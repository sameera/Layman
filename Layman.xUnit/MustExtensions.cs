using System;
using Xunit;

namespace Layman
{
    public static class MustExtensions
    {
        [Obsolete("Consider using FluentAssertions instead")]
        public static void Must_be<T>(this T actual, T expected) => Assert.Equal(expected, actual);
                           
        [Obsolete("Consider using FluentAssertions instead")]
        public static void Must_not_be<T>(this T actual, T unexpected) => Assert.NotEqual(unexpected, actual);
        
        [Obsolete("Consider using FluentAssertions instead")]
        public static void Must_match(this object value, string regex)
        {
            if (value == null)
            {
                Assert.True(false, "Expected a value matching the given Regex. Got a null value instead.");
            }
            else
            {
                Assert.Matches(regex, value.ToString());
            }
        }

        [Obsolete("Consider using FluentAssertions instead")]
        public static void Is_a<T>(this object tested) => Assert.IsType<T>(tested);

        [Obsolete("Consider using FluentAssertions instead")]
        public static void Is_assignable_from<T>(this object tested) => Assert.IsAssignableFrom<T>(tested);

        [Obsolete("Consider using FluentAssertions instead")]
        public static void Satisfies<T>(this T value, Func<T, bool> check) => Assert.True(check(value), $"{value} does not satisfy the given check");
    }

    //public class Negated<T>
    //{
    //    internal T Value { get; set; }
    //}
}
