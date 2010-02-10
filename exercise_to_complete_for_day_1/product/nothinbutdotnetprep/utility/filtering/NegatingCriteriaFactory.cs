namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatingCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> to_negate;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> to_negate)
        {
            this.to_negate = to_negate;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new NegatingCriteria<ItemToFilter>(to_negate.equal_to(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new NegatingCriteria<ItemToFilter>(to_negate.equal_to_any(values));
        }

    }
}