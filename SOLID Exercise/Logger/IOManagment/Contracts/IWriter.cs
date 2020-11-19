namespace Logger.Models.IOManagment
{
    public interface IWriter
    {
        void Write(string text);
        void WriteLine(string text);
    }
}
