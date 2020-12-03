using GameValues;
using System;
namespace Trap
{
    public class MineTrap
    {
        Random random = new Random();
        public int Damage { get; set; }
        public string[,] Mines { get; set; }
        
        public int MinePossitionOx { get; set; }
        public int MinePossitionOy { get; set; }

        public MineTrap()
        {
            Damage = random.Next(Values.minDamage, Values.maxDamage);
            Mines = new string[Values.maxGameRow, Values.maxGameCoulum];
        }

        public void CreateMinField()
        { 
            for (Values.FirstCounter = 0; Values.FirstCounter < Values.MinsNumbers; Values.FirstCounter++)
            {
                MinePossitionOx = random.Next(Values.minGameRow, Values.maxGameRow);
                MinePossitionOy = random.Next(Values.minGameCoulum, Values.maxGameCoulum);

                if (Mines[MinePossitionOx, MinePossitionOy] == null)
                {
                    if (MinePossitionOx != Values.prinsessPossitionOx && MinePossitionOy != Values.prinsessPossitionOy)
                    {
                        if (MinePossitionOx != Values.heroStartOx && MinePossitionOy != Values.heroStartOy)
                        {
                            Mines[MinePossitionOx, MinePossitionOy] = Values.heroAvatar;
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
