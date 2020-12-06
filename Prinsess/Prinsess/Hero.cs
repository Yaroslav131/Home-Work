using GameField;
using System;
using static System.Console;

namespace PersonHero
{
    public class Hero
    {
        public const string HeroAvatar = "H";
        public const int HeroStep = 1;
        public const int HeroStartOx = 1;
        public const int HeroStartOy = 1;
        public static int HitPoint { get; set; }
        public static int X { get; set; }
        public static int Y { get; set; }

        public Hero()
        {
            X = HeroStartOx;
            Y = HeroStartOy;
            HitPoint = 10;
        }

        public void MoveHero()
        {
            switch (ReadKey().Key)
            {
                case ConsoleKey.NumPad2:
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (Y == Field.MaxGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Y += HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (X == Field.MaxGameRow)
                    {
                        break;
                    }
                    else
                    {
                        X += HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad8:
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (Y == Field.MinGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Y -= HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (X == Field.MinGameRow)
                    {
                        break;
                    }
                    else
                    {
                        X -= HeroStep;
                    }
                    break;
            }
        }
    }
}
