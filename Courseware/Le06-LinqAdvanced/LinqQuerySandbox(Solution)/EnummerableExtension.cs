using System;
using System.Collections.Generic;

namespace LinqQuerySandbox
{
    public static class EnummerableExtension
    {
        public static IEnumerable<T> AwesomeSelect<T>(this IEnumerable<T> sequence, Func<T, T> transform)
        {

            foreach (T elem in sequence)
            {
                yield return transform(elem);

            }
        }
    }
}
