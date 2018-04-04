namespace Layman
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    [Obsolete("Consider using FluentAssertions instead")]
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

    public class Actual<T>
    {
        public T Value { get; }

        public Actual(T wrapped)
        {
            Value = wrapped;
        }
    }

    public class Negated<T>
    {
        public Negated(Actual<T> should)
        {
            this.Value = should.Value;
        }

        public T Value { get; }
    }

    public static class ShouldExtension
    {
        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_be<T>(this T actual, T expected) => EqualityComparer<T>.Default.Equals(actual, expected);

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_not_be<T>(this T actual, T unexpected) => !unexpected.Should_be(actual);

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Should_match(this object value, string regex) => value != null && new Regex(regex).IsMatch(value.ToString());

        [Obsolete("Consider using FluentAssertions instead")]
        public static bool Is_a(this object tested, Func<object, bool> check) => check(tested);

        //[Obsolete("Consider using FluentAssertions instead")]
        //public static Actual<T> Should<T>(this T any)
        //{
        //    return new Actual<T>(any);
        //}

        //[Obsolete("Consider using FluentAssertions instead")]
        //public static Negated<T> Not<T>(this Actual<T> any)
        //{
        //    return new Negated<T>(any);
        //}

        //[Obsolete("Consider using FluentAssertions instead")]
        //public static void Be<T>(this Actual<T> actual, T expected)
        //{
        //    Assert.Equal(expected, actual.Value);
        //}

        //[Obsolete("Consider using FluentAssertions instead")]
        //public static void Be<T>(this Negated<T> negated, T expected)
        //{
        //    Assert.NotEqual(expected, negated.Value);
        //}
    }
}
