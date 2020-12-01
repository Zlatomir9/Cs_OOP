namespace CommandPattern
{
    public interface ICommand
    {
        void ExecuteAction();
    }

    public enum PriceAction 
    {
        Increase,
        Decrease
    }
}
