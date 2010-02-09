using System;
using System.Collections;
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
            if (!movie_already_in_list(movie))
                movies.Add(movie);
        }

        bool movie_already_in_list(Movie m)
        {
            foreach (var movie in movies)
            {
                if (movie.title == m.title) return true;
            }

            return false;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            movies.Sort((Movie a, Movie b) => (String.Compare(b.title, a.title)));

            return all_movies();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_that_are_satisfied_by((Movie movie) => movie.production_studio == ProductionStudio.pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return
                all_movies_that_are_satisfied_by(
                                                    (Movie movie) =>
                                                    movie.production_studio == ProductionStudio.pixar || movie.production_studio == ProductionStudio.disney);
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


        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_that_are_satisfied_by(x => x.production_studio != ProductionStudio.pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_that_are_satisfied_by(movie1 => movie1.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_that_are_satisfied_by((Movie movie) => movie.date_published.Year <= endingYear && movie.date_published.Year >= startingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_that_are_satisfied_by((Movie movie) => movie.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_that_are_satisfied_by((Movie movie) => movie.genre == Genre.action);
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


        IEnumerable<Movie> all_movies_that_are_satisfied_by(Predicate<Movie> criteria)
        {
            foreach (var movie in movies)
            {
                if (criteria(movie)) yield return movie;
            }
        }
    }

    public class ReadOnlySetOf<T> : IEnumerable<T>
    {
        IList<T> movies;

        public ReadOnlySetOf(IList<T> movies)
        {
            this.movies = movies;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return movies.GetEnumerator();
        }
    }
}