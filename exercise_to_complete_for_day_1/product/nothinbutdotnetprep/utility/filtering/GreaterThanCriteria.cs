using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class GreaterThanCriteria<T> : Criteria<T> where T : IComparable<T>
    {
        T value;

        public GreaterThanCriteria(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(value) > 0;
        }
    }
}