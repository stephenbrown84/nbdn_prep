using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        List<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = (List<Movie>) list_of_movies;
        }


        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie other_movie)
        {
            foreach (var movie in movies)
            {
                if (movie.Equals(other_movie)) return true;
            }

            return false;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            movies.Sort((Movie a, Movie b) => (String.Compare(b.title, a.title)));

            return all_movies();
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            movies.Sort((Movie a, Movie b) => (String.Compare(a.title, b.title)));

            return all_movies();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            movies.Sort((Movie a, Movie b) =>
            {
                if (get_studio_rating(a) == get_studio_rating(b))
                {
                    if (a.date_published == b.date_published) return 0;
                    return a.date_published > b.date_published ? 1 : -1;
                }
                else
                {
                    if (get_studio_rating(a) == get_studio_rating(b)) return 0;
                    return get_studio_rating(a) > get_studio_rating(b) ? 1 : -1;
                }
            });

            return all_movies();
        }

        int get_studio_rating(Movie movie)
        {
            var ratings = new List<ProductionStudio>();

            ratings.Add(ProductionStudio.mgm);
            ratings.Add(ProductionStudio.pixar);
            ratings.Add(ProductionStudio.dreamworks);
            ratings.Add(ProductionStudio.universal);
            ratings.Add(ProductionStudio.disney);

            return ratings.IndexOf(movie.production_studio);
        }


        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            movies.Sort((Movie a, Movie b) =>
            {
                if (a.date_published == b.date_published) return 0;
                return a.date_published < b.date_published ? 1 : -1;
            });

            return all_movies();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            movies.Sort((Movie a, Movie b) =>
            {
                if (a.date_published == b.date_published) return 0;
                return a.date_published > b.date_published ? 1 : -1;
            });

            return all_movies();
        }
    }
}