namespace nothinbutdotnetprep.collections
{
    public class ProductionStudio
    {
        public static readonly ProductionStudio mgm = new ProductionStudio(1);
        public static readonly ProductionStudio paramount = new ProductionStudio(6);
        public static readonly ProductionStudio universal = new ProductionStudio(4);
        public static readonly ProductionStudio pixar = new ProductionStudio(2);
        public static readonly ProductionStudio disney = new ProductionStudio(5);
        public static readonly ProductionStudio dreamworks = new ProductionStudio(3);

        private ProductionStudio(int rating)
        {
            Rating = rating;
        }

        public int Rating { get; private set; }
    }
}