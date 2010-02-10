using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.sorting;

namespace nothinbutdotnetprep.utility.collections
{

    public class PrimarySort<ItemToSortType> : IEnumerable<ItemToSortType> 
    {
        private IEnumerable<ItemToSortType> original_list;
        private IComparer<ItemToSortType> sorter;

        public PrimarySort(IEnumerable<ItemToSortType> original_list, IComparer<ItemToSortType> sorter)
        {
            this.original_list = original_list;
            this.sorter = sorter;
        }

        public PrimarySort<ItemToSortType> then_by<PropertyType>(Func<ItemToSortType, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using<PropertyType>(new ChainedComparer<ItemToSortType>(this.sorter, new PropertyComparer<ItemToSortType, PropertyType>(property_accessor, true)));
        }

        public PrimarySort<ItemToSortType> then_by_descending<PropertyType>(Func<ItemToSortType, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using<PropertyType>(new ChainedComparer<ItemToSortType>(this.sorter, new PropertyComparer<ItemToSortType, PropertyType>(property_accessor, true)));
        }

        public PrimarySort<ItemToSortType> then_using<PropertyType>(IComparer<ItemToSortType> right_sorter)
            where PropertyType : IComparable<PropertyType>
        {
            var combined_sorter = new ChainedComparer<ItemToSortType>(sorter, right_sorter);
            return new PrimarySort<ItemToSortType>(original_list, combined_sorter);
        }

        public IEnumerator<ItemToSortType> GetEnumerator()
        {
            var my_items = new List<ItemToSortType>(original_list);
            my_items.Sort(sorter);
            return my_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
