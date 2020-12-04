using GameField;
using GameFunctions;
using GameValues;
using LineOutput;
using PersonHero;
using Trap;
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

                mine.CreateMinField();

                output.ShowTutorial();

                WriteLine("Press keyboard to start");
                do
                {
                    hero.MoveHero();

                    Clear();

                    gameField.TotalField[Values.Oy, Values.Ox] = Values.HeroAvatar;

                    if (Values.HeroAvatar == mine.Mines[Values.Oy, Values.Ox])
                    {
                        gameField.TotalField[Values.Oy, Values.Ox] = Values.MineAvatar;
                    }

                    gameField.TotalField[Values.PrinsessPossitionOx, Values.PrinsessPossitionOy] = Values.PrinsessAvatar;

                    WriteLine("Princess game");
                    WriteLine($"Your HP {Values.HitPoint}");

                    for (Values.FirstCounter = 0; Values.FirstCounter < Values.MaxFieldRow; Values.FirstCounter++)
                    {
                        for (Values.SecondCounter = 0; Values.SecondCounter < Values.MaxFieldCoulum; Values.SecondCounter++)
                        {
                            Write($"{  gameField.TotalField[Values.FirstCounter, Values.SecondCounter] }\t");
                        }
                        WriteLine();
                        WriteLine();
                    }
                    if (gameField.TotalField[Values.Oy, Values.Ox] == gameField.TotalField[Values.PrinsessPossitionOx, Values.PrinsessPossitionOy])
                    {
                        WriteLine("EEEEE Princess is safe!!! ");

                        gameFunction.EndCodition();
                    }
                    else if (Values.HeroAvatar == mine.Mines[Values.Oy, Values.Ox])
                    {
                        mine.Mines[Values.Oy, Values.Ox] = Values.MineAvatar;
                        Values.HitPoint -= mine.Damage;

                        if (Values.HitPoint <= 0)
                        {
                            WriteLine("GAME OVER");

                            gameFunction.EndCodition();
                        }
                    }
                    if (gameField.TotalField[Values.Oy, Values.Ox] != Values.MineAvatar)
                    {
                        gameField.TotalField[Values.Oy, Values.Ox] = Values.FieldCell;
                    }
                } while (Values.ExitGameСycle);

            } while (Values.ExitGame);
        }
    }
}