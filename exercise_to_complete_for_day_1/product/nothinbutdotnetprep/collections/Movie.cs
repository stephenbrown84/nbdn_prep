using System;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            return this.title == other.title;
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public static Predicate<Movie> is_published_by_pixar
        {
            get { return is_published_by(ProductionStudio.pixar); }
        }

        static Predicate<Movie> is_published_by(ProductionStudio production_studio)
        {
            return new IsPublishedBy(production_studio).is_satisfied_by;
        }

        public static Predicate<Movie> is_published_by_pixar_or_disney
        {
            get { return new IsPublishedBy(ProductionStudio.pixar).or(new IsPublishedBy(ProductionStudio.disney)).is_satisfied_by; }
        }

        public static Predicate<Movie> is_not_published_by_pixar
        {
            get { return movie => ! is_published_by(ProductionStudio.pixar)(movie); }
        }

        public static Predicate<Movie> is_published_after(int year)
        {
            return movie => movie.date_published.Year > year;
        }

        public static Predicate<Movie> is_published_between_years(int startingYear, int endingYear)
        {
            return movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear;
        }

        public static Predicate<Movie> is_a_kid_movie()
        {
            return new IsInGenre(Genre.kids).is_satisfied_by;
        }

        public static Predicate<Movie> is_an_action_movie()
        {
            return new IsInGenre(Genre.action).is_satisfied_by;
        }
    }
}