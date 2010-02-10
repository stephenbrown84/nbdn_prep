using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class PropertyCriteria<ItemToFilter, PropertyType> : Criteria<ItemToFilter>
    {
        Func<ItemToFilter, PropertyType> accessor;
        Criteria<PropertyType> value_criteria;

        public PropertyCriteria(Func<ItemToFilter, PropertyType> accessor, Criteria<PropertyType> value_criteria)
        {
            this.accessor = accessor;
            this.value_criteria = value_criteria;
        }

        public bool is_satisfied_by(ItemToFilter item)
        {
            return value_criteria.is_satisfied_by(accessor(item));
        }
    }
}