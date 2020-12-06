using GameField;
using System;
using static System.Console;

namespace PersonHero
{
    public class Hero
    {
        public static int HitPoint { get; set; } = 10;
        public const string HeroAvatar = "H";
        public const int HeroStep = 1;
        public const int HeroStartOx = 1;
        public const int HeroStartOy = 1;
        public static int Ox { get; set; } = HeroStartOx;
        public static int Oy { get; set; } = HeroStartOy;

        public void MoveHero()
        {
            switch (ReadKey().Key)
            {
                case ConsoleKey.NumPad2:
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (Oy == Field.MaxGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Oy += HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (Ox == Field.MaxGameRow)
                    {
                        break;
                    }
                    else
                    {
                        Ox += HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad8:
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (Oy == Field.MinGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Oy -= HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (Ox == Field.MinGameRow)
                    {
                        break;
                    }
                    else
                    {
                        Ox -= HeroStep;
                    }
                    break;
            }
        }
    }
}
