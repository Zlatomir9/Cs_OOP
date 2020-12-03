namespace Composite
{
    public class SingleGift : GiftBaseClass
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculatePrice()
        {
            return this.Price;
        }
    }
}
