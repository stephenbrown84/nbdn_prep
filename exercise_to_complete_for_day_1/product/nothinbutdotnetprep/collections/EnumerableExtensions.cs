using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_that_satisfy<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return all_that_satisfy(items, criteria.is_satisfied_by);
        }

        public static IEnumerable<T> all_that_satisfy<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            foreach (var item in items)
            {
                if (condition(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}