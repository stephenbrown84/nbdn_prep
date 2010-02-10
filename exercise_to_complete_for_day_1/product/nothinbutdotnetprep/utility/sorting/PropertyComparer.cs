using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        private Func<ItemToSort, PropertyType> accessor;
        private bool descending;

        public PropertyComparer(Func<ItemToSort, PropertyType> accessor, bool descending)
        {
            this.accessor = accessor;
            this.descending = descending;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            if (descending)
            {
                return accessor(y).CompareTo(accessor(x));
            }
            return accessor(x).CompareTo(accessor(y));
        }
    }
}