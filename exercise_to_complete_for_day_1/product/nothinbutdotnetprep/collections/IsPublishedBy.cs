using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : Criteria<Movie>
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }
        
        public bool is_satisfied_by(Movie movie)
        {
            return movie.production_studio == studio; 
        }
    }
}