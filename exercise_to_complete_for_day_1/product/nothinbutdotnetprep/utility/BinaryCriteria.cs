﻿namespace nothinbutdotnetprep.utility
{
    public abstract class BinaryCriteria<T> : Criteria<T>
    {
        protected Criteria<T> left_side;
        protected Criteria<T> right_side;

        public BinaryCriteria(Criteria<T> left_side, Criteria<T> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public abstract bool is_satisfied_by(T item);
    }
}