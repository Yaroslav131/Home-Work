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
        public static void Main(string[] args)
        {
            Field gameField = new Field();
            Game game = new Game();
            Hero hero = new Hero();
            Mine mine = new Mine();
            Output output = new Output();

            do
            {
                Clear();

                game.ResetGame();

                gameField.CreateField();

                mine.CreateMinesField();

                output.ShowTutorial();

                WriteLine("Press keyboard to start");

                do
                {
                    hero.MoveHero();

                    Clear();

                    gameField.TotalField[Hero.Y, Hero.X] = Hero.HeroAvatar;

                    if (Hero.HeroAvatar == mine.Mines[Hero.Y, Hero.X])
                    {
                        gameField.TotalField[Hero.Y, Hero.X] = Mine.MineAvatar;
                    }

                    gameField.TotalField[Prinses.PrinsessPossitionOx, Prinses.PrinsessPossitionOy] = Prinses.PrinsessAvatar;

                    WriteLine("Princess game");
                    WriteLine($"Your HP {Hero.HitPoint}");

                    for (int FirstCounter = 0; FirstCounter < Field.MaxFieldRow; FirstCounter++)
                    {
                        for (int SecondCounter = 0; SecondCounter < Field.MaxFieldCoulum; SecondCounter++)
                        {
                            Write($"{  gameField.TotalField[FirstCounter, SecondCounter] }\t");
                        }
                        WriteLine();
                        WriteLine();
                    }

                    if (gameField.TotalField[Hero.Y, Hero.X] == gameField.TotalField[Prinses.PrinsessPossitionOx, Prinses.PrinsessPossitionOy])
                    {
                        WriteLine("EEEEE Princess is safe!!! ");

                        game.SelectionAction();
                    }
                    else if (Hero.HeroAvatar == mine.Mines[Hero.Y, Hero.X])
                    {
                        mine.Mines[Hero.Y, Hero.X] = Mine.MineAvatar;
                        Hero.HitPoint -= mine.Damage;

                        if (Hero.HitPoint <= 0)
                        {
                            WriteLine("GAME OVER");

                            game.SelectionAction();
                        }
                    }

                    if (gameField.TotalField[Hero.Y, Hero.X] != Mine.MineAvatar)
                    {
                        gameField.TotalField[Hero.Y, Hero.X] = Field.FieldCell;
                    }
                }
                while (Game.ExitGameСycle);
            }
            while (Game.ExitGame);
        }
    }
}