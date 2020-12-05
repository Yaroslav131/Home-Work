using System;
using FieldValues;
using HeroValues;
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
                    if (HeroValue.Oy == FieldValue.MaxGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        HeroValue.Oy += HeroValue.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad6:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (HeroValue.Ox == FieldValue.MaxGameRow)
                    {
                        break;
                    }
                    else
                    {
                        HeroValue.Ox += HeroValue.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad8:
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (HeroValue.Oy == FieldValue.MinGameCoulum)
                    {
                        break;
                    }
                    else
                    {
                        HeroValue.Oy -= HeroValue.HeroStep;
                    }
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (HeroValue.Ox == FieldValue.MinGameRow)
                    {
                        break;
                    }
                    else
                    {
                        HeroValue.Ox -= HeroValue.HeroStep;
                    }
                    break;
            }
        }
    }
}
