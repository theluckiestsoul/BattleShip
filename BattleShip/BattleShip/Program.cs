using BattleShip.Business;
using BattleShip.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShip
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterDependencies();
            var application = serviceProvider.GetService<IApplication>();
            application.Start();
            System.Console.ReadKey();
        }

        private static ServiceProvider RegisterDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IInputProcessor, InputProcessor>();
            serviceCollection.AddSingleton<IConsoleReader, ConsoleReader>();
            serviceCollection.AddSingleton<IConsoleWriter, ConsoleWriter>();
            serviceCollection.AddSingleton<IApplication, BattleShipApplication>();
            serviceCollection.AddSingleton<IBattleAreaBusiness, BattleAreaBusiness>();
            serviceCollection.AddSingleton<IBattleShipBusiness, BattleShipBusiness>();
            serviceCollection.AddSingleton<IGame, Game>();
            serviceCollection.AddSingleton<IConverter, Converter>();
            serviceCollection.AddSingleton<IBattleShipValidator, BattleShipValidator>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
