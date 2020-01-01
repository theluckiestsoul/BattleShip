namespace BattleShip.Utility
{
    public interface IConsoleWriter
    {
        void WriteLine(string message);
        void WriteLine(string format, params object[] arg);
    }
}
