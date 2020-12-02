namespace Prototype
{
    public abstract class SandwichPrototype<T>
    {
        public abstract T ShallowCopy();

        public abstract T DeepCopy();
    }
}
