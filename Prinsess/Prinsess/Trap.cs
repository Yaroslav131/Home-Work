using GameValues;
using System;
namespace Trap
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
            Damage = random.Next(Values.MinDamage, Values.MaxDamage);
            Mines = new string[Values.MaxGameRow, Values.MaxGameCoulum];
        }

        public void CreateMinField()
        { 
            for (Values.FirstCounter = 0; Values.FirstCounter < Values.MinsNumbers; Values.FirstCounter++)
            {
                MinePossitionOx = random.Next(Values.MinGameRow, Values.MaxGameRow);
                MinePossitionOy = random.Next(Values.MinGameCoulum, Values.MaxGameCoulum);

                if (Mines[MinePossitionOx, MinePossitionOy] == null)
                {
                    if (MinePossitionOx != Values.PrinsessPossitionOx && MinePossitionOy != Values.PrinsessPossitionOy)
                    {
                        if (MinePossitionOx != Values.HeroStartOx && MinePossitionOy != Values.HeroStartOy)
                        {
                            Mines[MinePossitionOx, MinePossitionOy] = Values.HeroAvatar;
                        }
                    }   
                }
                else
                {
                    Values.MinsNumbers++;
                }
            }
        }
    }
}
