using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class EqualToAnyCriteria<T> : Criteria<T>
    {
        IEnumerable<T> values;

        public EqualToAnyCriteria(params T[] values)
        {
            this.values = values;
        }

        public bool is_satisfied_by(T item)
        {
            return new List<T>(values).Contains(item);
        }
    }
}