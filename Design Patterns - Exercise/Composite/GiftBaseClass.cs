namespace Composite
{
    public abstract class GiftBaseClass
    {
        protected GiftBaseClass(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string  Name { get; set; }

        public int Price { get; set; }

        public abstract int CalculatePrice();
    }
}
