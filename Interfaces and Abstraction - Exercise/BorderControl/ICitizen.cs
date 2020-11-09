namespace BorderControl
{
    public interface ICitizen : IRobot, IPet
    {
        public int Age { get; }
    }
}
