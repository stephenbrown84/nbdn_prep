using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        private List<Movie> _allMovies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            _allMovies = (List<Movie>)list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in _allMovies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (!movie_already_in_list(movie))
            {
                _allMovies.Add(movie);    
            }
            
        }

        private bool movie_already_in_list(Movie m)
        {
            foreach (var movie in _allMovies)
            {
                if (movie.title == m.title) return true;
            }

            return false;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            _allMovies.Sort(delegate(Movie a, Movie b)
            {
                return (String.Compare(b.title, a.title));

            });

            return all_movies();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in _allMovies)
            {
                if (movie.production_studio == ProductionStudio.pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in _allMovies)
            {
                if (movie.production_studio == ProductionStudio.pixar || movie.production_studio == ProductionStudio.disney)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            _allMovies.Sort(delegate(Movie a, Movie b)
            {
                return (String.Compare(a.title, b.title));
   
            });

            return all_movies();
            
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            _allMovies.Sort(delegate(Movie a, Movie b)
            {
                if (a.production_studio.Rating.Equals(b.production_studio.Rating))
                    return a.date_published.Year.CompareTo(b.date_published.Year);
                return a.production_studio.Rating.CompareTo(b.production_studio.Rating);
            });

            return all_movies();
        }

        private int get_studio_rating(Movie movie)
        {
            List<ProductionStudio> ratings = new List<ProductionStudio>();

            ratings.Add(ProductionStudio.mgm);
            ratings.Add(ProductionStudio.pixar);
            ratings.Add(ProductionStudio.dreamworks);
            ratings.Add(ProductionStudio.universal);
            ratings.Add(ProductionStudio.disney);

            return ratings.IndexOf(movie.production_studio);

        }


        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in _allMovies)
            {
                if (movie.production_studio != ProductionStudio.pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in _allMovies)
            {
                if (movie.date_published.Year > year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in _allMovies)
            {
                if (movie.date_published.Year <= endingYear && movie.date_published.Year >= startingYear)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in _allMovies)
            {
                if (movie.genre == Genre.kids)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in _allMovies)
            {
                if (movie.genre == Genre.action)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            _allMovies.Sort(delegate(Movie a, Movie b)
            {
                if (a.date_published == b.date_published) return 0;
                return a.date_published < b.date_published ? 1 : -1;
            });

            return all_movies();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {

            _allMovies.Sort(delegate(Movie a, Movie b)
            {
                if (a.date_published == b.date_published) return 0;
                return a.date_published > b.date_published ? 1:  -1;
            });

            return all_movies();
        }
    }
}