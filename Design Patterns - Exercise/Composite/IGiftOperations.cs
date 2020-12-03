namespace Composite
{
    public interface IGiftOperations
    {
        void Add(GiftBaseClass giftBaseClass);

        bool Remove(GiftBaseClass giftBaseClass);
    }
}
