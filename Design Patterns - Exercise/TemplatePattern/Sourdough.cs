using System;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough (20 min)");
        }

        public override void Slice()
        {
        }
    }
}
