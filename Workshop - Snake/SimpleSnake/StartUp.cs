namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;
    using SimpleSnake.Core;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall, 1, 6);
            Engine engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}
