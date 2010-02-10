using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.collections;
using nothinbutdotnetprep.utility.filtering;
using nothinbutdotnetprep.utility.sorting;

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

        public static PrimarySort<T> sorted_by<T, C>(this IEnumerable<T> items, Func<T, C> accessor) 
            where C : IComparable<C>
        {
            return new PrimarySort<T>(items, new PropertyComparer<T, C>(accessor, false));
        }

        public static PrimarySort<T> sorted_by<T, C>(this IEnumerable<T> items, Func<T, C> accessor, params C[] values)
        {
            return new PrimarySort<T>(items, new ProvidedPropertyComparer<T, C>(accessor, false, values));
        }

        public static PrimarySort<T> sorted_by_descending<T, C>(this IEnumerable<T> items, Func<T, C> accessor)
            where C : IComparable<C>
        {
            return new PrimarySort<T>(items, new PropertyComparer<T, C>(accessor, true));
        }
    }
}