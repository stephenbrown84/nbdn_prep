using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility
{
    public class Where_t<ItemToFilter>
    {
        //public static ProductionStudio has_a(ProductionStudio productionStudio)
        //{
        //    return productionStudio;
        //}
        public static CriteriaFactory<ItemToFilter,ProductionStudio> has_a(Func<ItemToFilter, ProductionStudio> func)
        {
            return func;
        }
    }

    public class CriteriaFactory<ItemToFilter, ProductionStudio>
    {
        Func<ItemToFilter, ProductionStudio> accessory;

        public Movie Equal_To(ProductionStudio productionStudio)
        {
            
        }
    }
}