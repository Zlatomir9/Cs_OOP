using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleGift = new SingleGift("Test", 10);
            Console.WriteLine(singleGift.CalculatePrice());

            var compositeGifts = new CompositeClass("RootBox", 0);
            var singleGift2 = new SingleGift("test", 20);
            var singleGift3 = new SingleGift("t", 50);

            compositeGifts.Add(singleGift2);
            compositeGifts.Add(singleGift3);

            Console.WriteLine(compositeGifts.CalculatePrice());
        }
    }
}
