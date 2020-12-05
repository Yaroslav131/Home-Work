using GameValues;
using MineValues;
using FieldValues;
using HeroValues;
using PrinsesValues;
using System;

namespace Mines
{
    public class Mine
    {
        Random random = new Random();
        public int Damage { get; set; }
        public string[,] Mines { get; set; }
        
        public int MinePossitionOx { get; set; }
        public int MinePossitionOy { get; set; }

        public Mine()
        {
            Damage = random.Next(MineValue.MinDamage, MineValue.MaxDamage);
            Mines = new string[FieldValue.MaxGameRow, FieldValue.MaxGameCoulum];
        }

        public void CreateMinesField()
        { 
            for (GameValue.FirstCounter = 0; GameValue.FirstCounter < MineValue.MinsNumbers; GameValue.FirstCounter++)
            {
                MinePossitionOx = random.Next(FieldValue.MinGameRow, FieldValue.MaxGameRow);
                MinePossitionOy = random.Next(FieldValue.MinGameCoulum, FieldValue.MaxGameCoulum);

                if (Mines[MinePossitionOx, MinePossitionOy] == null)
                {
                    if (MinePossitionOx != PrinsesValue.PrinsessPossitionOx && MinePossitionOy != PrinsesValue.PrinsessPossitionOy)
                    {
                        if (MinePossitionOx != HeroValue.HeroStartOx && MinePossitionOy != HeroValue.HeroStartOy)
                        {
                            Mines[MinePossitionOx, MinePossitionOy] = HeroValue.HeroAvatar;
                        }
                    }   
                }
                else
                {
                    MineValue.MinsNumbers++;
                }
            }
        }
    }
}
