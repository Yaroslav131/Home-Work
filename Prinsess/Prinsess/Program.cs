using GameField;
using FieldValues;

using GameFunctions;
using GameValues;

using Mines;
using MineValues;
using PersonHero;
using HeroValues;
using PrinsesValues;
using LineOutput;
using static System.Console;

namespace Princess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field gameField = new Field();
            GameFunction gameFunction = new GameFunction();
            Hero hero = new Hero();
            Mine mine = new Mine();
            Output output = new Output();

            do
            {
                Clear();

                gameFunction.Reset();

                gameField.CreateField();

                mine.CreateMinesField();

                output.ShowTutorial();

                WriteLine("Press keyboard to start");
                do
                {
                    hero.MoveHero();

                    Clear();

                    gameField.TotalField[HeroValue.Oy, HeroValue.Ox] = HeroValue.HeroAvatar;

                    if (HeroValue.HeroAvatar == mine.Mines[HeroValue.Oy, HeroValue.Ox])
                    {
                        gameField.TotalField[HeroValue.Oy, HeroValue.Ox] = MineValue.MineAvatar;
                    }

                    gameField.TotalField[PrinsesValue.PrinsessPossitionOx, PrinsesValue.PrinsessPossitionOy] = PrinsesValue.PrinsessAvatar;

                    WriteLine("Princess game");
                    WriteLine($"Your HP {HeroValue.HitPoint}");

                    for (GameValue.FirstCounter = 0; GameValue.FirstCounter < FieldValue.MaxFieldRow; GameValue.FirstCounter++)
                    {
                        for (GameValue.SecondCounter = 0; GameValue.SecondCounter < FieldValue.MaxFieldCoulum; GameValue.SecondCounter++)
                        {
                            Write($"{  gameField.TotalField[GameValue.FirstCounter, GameValue.SecondCounter] }\t");
                        }
                        WriteLine();
                        WriteLine();
                    }
                    if (gameField.TotalField[HeroValue.Oy, HeroValue.Ox] == gameField.TotalField[PrinsesValue.PrinsessPossitionOx, PrinsesValue.PrinsessPossitionOy])
                    {
                        WriteLine("EEEEE Princess is safe!!! ");

                        gameFunction.EndCodition();
                    }
                    else if (HeroValue.HeroAvatar == mine.Mines[HeroValue.Oy, HeroValue.Ox])
                    {
                        mine.Mines[HeroValue.Oy, HeroValue.Ox] = MineValue.MineAvatar;
                        HeroValue.HitPoint -= mine.Damage;

                        if (HeroValue.HitPoint <= 0)
                        {
                            WriteLine("GAME OVER");

                            gameFunction.EndCodition();
                        }
                    }
                    if (gameField.TotalField[HeroValue.Oy, HeroValue.Ox] != MineValue.MineAvatar)
                    {
                        gameField.TotalField[HeroValue.Oy, HeroValue.Ox] = FieldValue.FieldCell;
                    }
                } while (GameValue.ExitGameСycle);

            } while (GameValue.ExitGame);
        }
    }
}