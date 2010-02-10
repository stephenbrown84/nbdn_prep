namespace nothinbutdotnetprep.utility
{
    public class NegatingCriteria<T> : Criteria<T>
    {
        Criteria<T> to_negate;

        public NegatingCriteria(Criteria<T> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool is_satisfied_by(T item)
        {
            return ! to_negate.is_satisfied_by(item);
        }
    }
}