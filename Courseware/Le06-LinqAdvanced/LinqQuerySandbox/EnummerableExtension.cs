using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqQuerySandbox
{
    public static class EnummerableExtension
    {
        public static IEnumerable AwesomeSelect(this IEnumerable<int> folge, Func<int, int> func )
        {
            var returnList = new IEnumerable<int>();
            foreach (var item in folge)
            {
                func(item);
            }

            return folge;
        }
    }
}
