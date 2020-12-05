namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int Points = 2;

        public FoodDollar(Wall wall) 
            : base(wall, foodSymbol, Points)
        {
        }
    }
}
