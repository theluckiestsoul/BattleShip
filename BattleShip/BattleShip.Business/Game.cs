using BattleShip.Entities.DTO;
using BattleShip.Utility;
using BattleShip.Utility.Constants;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    public class Game : IGame
    {
        private IConsoleWriter _consoleWriter;
        public Game(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public void Start(BattleAreaDto battle1, BattleAreaDto battle2, string player1Missile, string player2Missile)
        {
            List<string> missilesP1 = player1Missile.Split(' ').ToList();
            List<string> missilesP2 = player2Missile.Split(' ').ToList();
            var battleArea2Cells = battle2.BattleShips.SelectMany(bs => bs.BattleAreaCellDtos).ToList();
            var battleArea1Cells = battle1.BattleShips.SelectMany(bs => bs.BattleAreaCellDtos).ToList();
            while (missilesP1.Count != 0 || missilesP2.Count != 0)
            {
                if (missilesP1.Count == 0 && missilesP2.Count == 0)
                {
                    _consoleWriter.WriteLine(ConsoleMessage.MATCH_DRAWN);
                    return;
                }
                if (missilesP1.Count == 0)
                {
                    _consoleWriter.WriteLine(ConsoleMessage.NO_MISSILES_LEFT,ConsoleMessage.PLAYER1);
                }
                while (missilesP1.Count != 0)
                {
                    
                    string target = missilesP1[0];
                    var cell = battleArea2Cells.FirstOrDefault(ba => ba.CellName == target);
                    missilesP1.Remove(target);
                    if (cell == null)
                    {
                        _consoleWriter.WriteLine(ConsoleMessage.MISSILE_GOT_MISS,ConsoleMessage.PLAYER1,target);
                        break;
                    }
                    _consoleWriter.WriteLine(ConsoleMessage.MISSILE_GOT_HIT, ConsoleMessage.PLAYER1, target);

                    cell.HitsRequiredToDestroy -= 1;
                    battleArea2Cells.RemoveAll(ba => ba.HitsRequiredToDestroy <= 0);
                    if (battleArea2Cells.Count == 0)
                    {
                        _consoleWriter.WriteLine(ConsoleMessage.BATTLE_WON,ConsoleMessage.PLAYER1);
                        return;
                    }
                    continue;
                }
                if (missilesP2.Count == 0)
                {
                    _consoleWriter.WriteLine(ConsoleMessage.NO_MISSILES_LEFT,ConsoleMessage.PLAYER2);
                }
                while (missilesP2.Count != 0)
                {
                    
                    string target = missilesP2[0];
                    var cell = battleArea1Cells.FirstOrDefault(ba => ba.CellName == target);
                    missilesP2.Remove(target);
                    if (cell == null)
                    {
                        _consoleWriter.WriteLine(ConsoleMessage.MISSILE_GOT_MISS, ConsoleMessage.PLAYER2,target);
                        break;
                    }
                    _consoleWriter.WriteLine(ConsoleMessage.MISSILE_GOT_HIT, ConsoleMessage.PLAYER2,target);

                    cell.HitsRequiredToDestroy -= 1;
                    battleArea1Cells.RemoveAll(ba => ba.HitsRequiredToDestroy <= 0);
                    if (battleArea1Cells.Count == 0)
                    {
                        _consoleWriter.WriteLine(ConsoleMessage.BATTLE_WON,ConsoleMessage.PLAYER2);
                        return;
                    }
                    continue;
                }
            }

        }


    }
}
