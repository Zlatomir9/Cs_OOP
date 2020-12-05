namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '■';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.SetHorizontalLile(0);
            this.SetHorizontalLile(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }

        private void SetHorizontalLile(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
