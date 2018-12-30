using System;

namespace SimpleDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            // ConsoleEngine engine = new ConsoleEngine();
            // engine.Launch();

            WorldCreator creator = new WorldCreator();
            creator.ShowMainMenu();
        }
    }
}
