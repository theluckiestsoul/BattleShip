namespace BattleShip.Utility
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
           return System.Console.ReadLine();
        }
    }
}
