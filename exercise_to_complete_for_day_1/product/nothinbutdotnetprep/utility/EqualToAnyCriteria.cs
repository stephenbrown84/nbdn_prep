using System;

namespace nothinbutdotnetprep.utility
{
    public class EqualToAnyCriteria<T> : Criteria<T>
    {
        private T[] _values;

        public EqualToAnyCriteria(T[] values)
        {
            this._values = values;
        }
        public bool is_satisfied_by(T item)
        {
            foreach (var value in _values)
            {
                if (item.Equals(value))
                {
                    return true;
                } 
            }

            return false;
        }
    }
}