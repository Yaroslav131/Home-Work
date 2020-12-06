using GameField;
using GameFunctions;
using PersonHero;
using PrinsesValues;
using System;

namespace Mines
{
    public class Mine
    {
        Random random = new Random();

        public const string MineAvatar = "¤";
        public static int MinsNumbers { get; set; } = 10;
        public const int MaxDamage = 10;
        public const int MinDamage = 1;
        public int Damage { get; set; }
        public string[,] Mines { get; set; }

        public int MinePossitionOx { get; set; }
        public int MinePossitionOy { get; set; }

        public Mine()
        {
            Damage = random.Next(MinDamage, MaxDamage);
            Mines = new string[Field.MaxGameRow, Field.MaxGameCoulum];
        }

        public void CreateMinesField()
        {
            for (GameFunction.FirstCounter = 0; GameFunction.FirstCounter < MinsNumbers; GameFunction.FirstCounter++)
            {
                MinePossitionOx = random.Next(Field.MinGameRow, Field.MaxGameRow);
                MinePossitionOy = random.Next(Field.MinGameCoulum, Field.MaxGameCoulum);

                if (Mines[MinePossitionOx, MinePossitionOy] == null)
                {
                    if (MinePossitionOx != Prinses.PrinsessPossitionOx && MinePossitionOy != Prinses.PrinsessPossitionOy)
                    {
                        if (MinePossitionOx != Hero.HeroStartOx && MinePossitionOy != Hero.HeroStartOy)
                        {
                            Mines[MinePossitionOx, MinePossitionOy] = Hero.HeroAvatar;
                        }
                    }
                }
                else
                {
                    MinsNumbers++;
                }
            }
        }
    }
}
