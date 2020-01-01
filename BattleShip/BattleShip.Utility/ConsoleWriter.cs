namespace BattleShip.Utility
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void WriteLine(string format, params object[] arg)
        {
            System.Console.WriteLine(format, arg);
        }
    }
}
