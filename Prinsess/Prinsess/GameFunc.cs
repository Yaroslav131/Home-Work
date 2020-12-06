using GameField;
using PersonHero;
using System;
using static System.Console;

namespace GameFunctions
{
    public class Game
    {
        public static bool UnknownKey { get; set; }
        public static bool ExitGameСycle { get; set; }
        public static bool ExitGame { get; set; }

        public void SelectionAction()
        {
            do
            {
                WriteLine("Do you want start new game? Enter/Escape ");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        ExitGameСycle = false;
                        ExitGame = true;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        ExitGameСycle = false;
                        ExitGame = false;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        Clear();
                        break;
                }
            }
            while (UnknownKey);
        }

        public void ResetGame()
        {
            Hero.X = Field.MinGameRow;
            Hero.Y = Field.MinGameCoulum;
            Hero.HitPoint = 10;
            ExitGameСycle = true;
            ExitGame = false;
        }
    }
}
