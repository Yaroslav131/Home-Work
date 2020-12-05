using GameValues;
using System;
using HeroValues;
using FieldValues;
using static System.Console;

namespace GameFunctions
{
    public class GameFunction
    {
        public void EndCodition()
        {
            do
            {
                WriteLine("Do you want start new game? Enter/Escape ");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        GameValue.ExitGameСycle = false;
                        GameValue.ExitGame = true;
                        GameValue.UnknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        GameValue.ExitGameСycle = false;
                        GameValue.ExitGame = false;
                        GameValue.UnknownKey = false;
                        break;

                    default:
                        GameValue.UnknownKey = true;
                        Clear();
                        break;
                }
            } 
            while (GameValue.UnknownKey);
        }

        public void Reset()
        {
            HeroValue.Ox = FieldValue.MinGameRow;
            HeroValue.Oy = FieldValue.MinGameCoulum;
            HeroValue.HitPoint = 10;
            GameValue.ExitGameСycle = true;
            GameValue.ExitGame = false;
        }
    }
}
