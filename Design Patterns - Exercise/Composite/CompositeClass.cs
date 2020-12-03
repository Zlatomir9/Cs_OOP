using System.Collections.Generic;

namespace Composite
{
    public class CompositeClass : GiftBaseClass, IGiftOperations
    {
        private ICollection<GiftBaseClass> giftBaseClasses;

        public CompositeClass(string name, int price) 
            : base(name, price)
        {
            this.giftBaseClasses = new List<GiftBaseClass>();
        }

        public void Add(GiftBaseClass giftBaseClass)
        {
            this.giftBaseClasses.Add(giftBaseClass);
        }

        public bool Remove(GiftBaseClass giftBaseClass)
        {
            return this.giftBaseClasses.Remove(giftBaseClass);
        }

        public override int CalculatePrice()
        {
            var totalPrice = 0;

            foreach (var item in this.giftBaseClasses)
            {
                totalPrice += item.CalculatePrice();
            }

            return totalPrice;
        }
    }
}
