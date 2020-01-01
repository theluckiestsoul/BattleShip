using BattleShip.Utility;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BattleShip.Tests.ConsoleTests
{
    public class BattleShipApplicationTest
    {
        [Fact]
        public void BattleShipApplication_Start_ShouldCall_ProcessInput_Once()
        {
            List<string> list = new List<string>();
            Mock<IConsoleReader> consoleReaderMock = new Mock<IConsoleReader>();
            Mock<IInputProcessor> inputProcessorMock = new Mock<IInputProcessor>();
            Mock<IConsoleWriter> consoleWriterMock = new Mock<IConsoleWriter>();
            BattleShipApplication battleShipApplication = new BattleShipApplication(consoleReaderMock.Object, inputProcessorMock.Object, consoleWriterMock.Object);
            battleShipApplication.Start();
            inputProcessorMock.Verify(i => i.ProcessInput(list), Times.Once);
        }
    }
}
