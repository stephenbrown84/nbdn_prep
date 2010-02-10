using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> basic;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.accessor = accessor;
            this.basic = basic;
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return basic.equal_to_any(values);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return basic.equal_to(value);
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