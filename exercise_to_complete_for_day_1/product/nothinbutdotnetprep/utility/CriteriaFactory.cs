using System;
using nothinbutdotnetprep.collections;

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
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<Movie> equal_to_any(params PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}