using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new GreaterThanCriteria<PropertyType>(value));
        }

        public Criteria<ItemToFilter> between(PropertyType min, PropertyType max)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new FallsInRangeCriteria<PropertyType>(new InclusiveRange<PropertyType>(min, max)));
        }
    }
}