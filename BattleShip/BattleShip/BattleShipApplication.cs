using BattleShip.Utility;
using BattleShip.Utility.Constants;
using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class BattleShipApplication : IApplication
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IInputProcessor _inputProcessor;
        private readonly IConsoleWriter _consoleWriter;
        public BattleShipApplication(IConsoleReader consoleReader, IInputProcessor inputProcessor, IConsoleWriter consoleWriter)
        {
            _consoleReader = consoleReader;
            _inputProcessor = inputProcessor;
            _consoleWriter = consoleWriter;

        }
        public void Start()
        {
            _inputProcessor.ProcessInput(ReadInputs());
        }

        private List<string> ReadInputs()
        {
            List<string> inputList = new List<string>();
            _consoleWriter.WriteLine(ConsoleMessage.ENTER_INPUT);
            _consoleWriter.WriteLine(ConsoleMessage.NOTE_TO_USER);
            while (true)
            {
                string input = _consoleReader.ReadLine();
                
                if (string.IsNullOrWhiteSpace(input) || input.Equals(ConsoleMessage.START,StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                inputList.Add(input);
            }
            return inputList;
        }

    }
}
