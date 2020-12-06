using GameField;
using GameFunctions;
using LineOutput;
using Mines;
using PersonHero;
using PrinsesValues;
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

                    gameField.TotalField[Hero.Oy, Hero.Ox] = Hero.HeroAvatar;

                    if (Hero.HeroAvatar == mine.Mines[Hero.Oy, Hero.Ox])
                    {
                        gameField.TotalField[Hero.Oy, Hero.Ox] = Mine.MineAvatar;
                    }

                    gameField.TotalField[Prinses.PrinsessPossitionOx, Prinses.PrinsessPossitionOy] = Prinses.PrinsessAvatar;

                    WriteLine("Princess game");
                    WriteLine($"Your HP {Hero.HitPoint}");

                    for (int FirstCounter = 0; FirstCounter < Field.MaxFieldRow; FirstCounter++)
                    {
                        for ( int SecondCounter = 0; SecondCounter < Field.MaxFieldCoulum; SecondCounter++)
                        {
                            Write($"{  gameField.TotalField[FirstCounter, SecondCounter] }\t");
                        }
                        WriteLine();
                        WriteLine();
                    }
                    if (gameField.TotalField[Hero.Oy, Hero.Ox] == gameField.TotalField[Prinses.PrinsessPossitionOx, Prinses.PrinsessPossitionOy])
                    {
                        WriteLine("EEEEE Princess is safe!!! ");

                        gameFunction.EndCodition();
                    }
                    else if (Hero.HeroAvatar == mine.Mines[Hero.Oy, Hero.Ox])
                    {
                        mine.Mines[Hero.Oy, Hero.Ox] = Mine.MineAvatar;
                        Hero.HitPoint -= mine.Damage;

                        if (Hero.HitPoint <= 0)
                        {
                            WriteLine("GAME OVER");

                            gameFunction.EndCodition();
                        }
                    }
                    if (gameField.TotalField[Hero.Oy, Hero.Ox] != Mine.MineAvatar)
                    {
                        gameField.TotalField[Hero.Oy, Hero.Ox] = Field.FieldCell;
                    }
                } while (GameFunction.ExitGameСycle);

            } while (GameFunction.ExitGame);
        }
    }
}