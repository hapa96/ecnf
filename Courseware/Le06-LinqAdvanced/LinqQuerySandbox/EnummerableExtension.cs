using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqQuerySandbox
{
    public static class EnummerableExtension
    {
        public static IEnumerable<T> AwesomeSelect<T>(this IEnumerable<T> input, Func<T, T> func )
        {
            foreach (var item in input)
            {
                yield return func(item);

            }
        }
    }
}