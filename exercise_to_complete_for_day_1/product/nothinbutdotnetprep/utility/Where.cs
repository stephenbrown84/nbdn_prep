using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility
{
    public class Where<T>
    {
        public static Condition<T> has_a(Func<Movie,ProductionStudio> func)
        {
            return new Condition<T>(func);
        }
    }

    public class Condition<T>
    {
        private Func<Movie, ProductionStudio> _criteria;
        private ProductionStudio _studio;

        public Condition(Func<Movie, ProductionStudio> criteria)
        {
            _criteria = criteria;
        }

        public Predicate<Movie> equal_to(ProductionStudio studio)
        {
            _studio = studio;
            return check_condition;
        }

        private bool check_condition(Movie movie)
        {
            return _criteria(movie) == _studio;
        }
    }
}