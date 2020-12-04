using GameValues;
using System;
using System.Threading;
using static System.Console;
namespace GameFunctions
{
    public class GameFunction
    {
        public void EndCodition()
        {
            Thread.Sleep(2000);

            Clear();
            do
            {
                WriteLine("Do you want start new game? Enter/Escape ");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Values.ExitGameСycle = false;
                        Values.ExitGame = true;
                        Values.UnknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        Values.ExitGameСycle = false;
                        Values.ExitGame = false;
                        Values.UnknownKey = false;
                        break;

                    default:
                        Values.UnknownKey = true;
                        Clear();
                        break;
                }
            } while (Values.UnknownKey);
        }
        public void Reset()
        {
            Values.Ox = Values.minGameRow;
            Values.Oy = Values.minGameCoulum;
            Values.HitPoint = 10;
            Values.ExitGameСycle = true;
            Values.ExitGame = false;
        }
    }
}
