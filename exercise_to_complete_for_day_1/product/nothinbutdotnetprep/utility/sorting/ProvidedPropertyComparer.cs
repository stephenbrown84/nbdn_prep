using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ProvidedPropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> 
    {
        private Func<ItemToSort, PropertyType> accessor;
        private bool descending;
        private List<PropertyType> items;

        public ProvidedPropertyComparer(Func<ItemToSort, PropertyType> accessor, bool descending, params PropertyType[] items)
        {
            this.accessor = accessor;
            this.descending = descending;
            this.items = new List<PropertyType>(items);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            if (descending)
            {
                return items.IndexOf(accessor(y)).CompareTo(items.IndexOf(accessor(x)));
            }
            return items.IndexOf(accessor(x)).CompareTo(items.IndexOf(accessor(y)));
        }
    }
}