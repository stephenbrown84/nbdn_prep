using System;

namespace nothinbutdotnetprep.utility
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).Equals(value));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToFilter>(equal_to(value));
        }
    }

    public class ComparisonCriteriaFactory<ItemToFilter, PropertyType> where PropertyType :IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        public ComparisonCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) == 1);
        }

        public Criteria<ItemToFilter> is_between(PropertyType min, PropertyType max)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(min) >= 0 && accessor(x).CompareTo(max) <= 0);
        }
        
    }
}