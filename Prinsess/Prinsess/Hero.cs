using GameValues;
using System;
using static System.Console;
namespace PersonHero
{
    public class Hero
    {
        public void MoveHero()
        {
            switch (ReadKey().Key)
            {
                case ConsoleKey.NumPad2:
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (Values.Oy == Values.MaxGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Values.Oy += Values.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (Values.Ox == Values.MaxGameRow)
                    {
                        break;
                    }
                    else
                    {
                        Values.Ox += Values.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad8:
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (Values.Oy == Values.MinGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        Values.Oy -= Values.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (Values.Ox == Values.MinGameRow)
                    {
                        break;
                    }
                    else
                    {
                        Values.Ox -= Values.HeroStep;
                    }
                    break;
            }
        }
    }
}
