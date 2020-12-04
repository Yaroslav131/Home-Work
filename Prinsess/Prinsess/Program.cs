using GameField;
using GameFunctions;
using GameValues;
using LineOutput;
using Trap;
using PersonHero;
using static System.Console;
namespace Princess
{
    class Program
    {
        static void Main(string[] args)
        {
            Field gameField = new Field();
            GameFunction gameFunction = new GameFunction();
            Hero hero = new Hero();
            MineTrap mineTrape = new MineTrap();
            Output output = new Output();

            do
            {
                Clear();

                gameFunction.Reset();

                gameField.CreateField();

                mineTrape.CreateMinField();

                output.ShowTutorial();

                WriteLine("Press keyboard to start");
                do
                {
                    hero.MoveHero();
                    Clear();

                    gameField.TotalField[Values.Oy, Values.Ox] = Values.heroAvatar;

                    if (Values.heroAvatar == mineTrape.Mines[Values.Oy, Values.Ox])
                    {
                        gameField.TotalField[Values.Oy, Values.Ox] = Values.MineAvatar;
                    }

                    gameField.TotalField[Values.prinsessPossitionOx, Values.prinsessPossitionOy] = Values.prinsessAvatar;

                    WriteLine("Princess game");
                    WriteLine($"Your HP {Values.HitPoint}");

                    for (Values.FirstCounter = 0; Values.FirstCounter < Values.maxFieldRow; Values.FirstCounter++)
                    {
                        for (Values.SecondCounter = 0; Values.SecondCounter < Values.maxFieldCoulum; Values.SecondCounter++)
                        {
                            Write($"{  gameField.TotalField[Values.FirstCounter, Values.SecondCounter] }\t");
                        }
                        WriteLine();
                        WriteLine();
                    }
                    if (gameField.TotalField[Values.Oy, Values.Ox] == gameField.TotalField[Values.prinsessPossitionOx, Values.prinsessPossitionOy])
                    {
                        WriteLine("EEEEE Princess is safe!!! ");

                        gameFunction.EndCodition();
                    }
                    else if (Values.heroAvatar == mineTrape.Mines[Values.Oy, Values.Ox])
                    {
                        mineTrape.Mines[Values.Oy, Values.Ox] = Values.MineAvatar;
                        Values.HitPoint -= mineTrape.Damage;

                        if (Values.HitPoint <= 0)
                        {
                            WriteLine("GAME OVER");

                            gameFunction.EndCodition();
                        }
                    }
                    if (gameField.TotalField[Values.Oy, Values.Ox] != Values.MineAvatar)
                    {
                        gameField.TotalField[Values.Oy, Values.Ox] = Values.fieldCell;
                    }
                } while (Values.ExitGameСycle);

            } while (Values.ExitGame);
        }
    }
}