using System;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread (15 min)");
        }

        public override void Slice()
        {
        }
    }
}
