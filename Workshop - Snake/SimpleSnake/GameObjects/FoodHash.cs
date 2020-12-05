namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int Points = 3;

        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, Points)
        {
        }
    }
}
