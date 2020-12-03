using GameValues;
namespace GameField
{
    public class Field
    {
        public string[,] TotalField { get; set; }

        public Field()
        {
            TotalField = new string[Values.maxFieldRow, Values.maxFieldCoulum];
        }

        public void CreatField()
        {
            for (Values.FirstCounter = 0; Values.FirstCounter < Values.maxFieldRow; Values.FirstCounter++)
            {
                TotalField[0, Values.FirstCounter] = Values.horizontaFieldlBorder;
                TotalField[Values.maxFieldRow - 1, Values.FirstCounter] = Values.horizontaFieldlBorder;
            }
            for (Values.FirstCounter = 1; Values.FirstCounter < Values.maxFieldCoulum - 1; Values.FirstCounter++)
            {
                TotalField[Values.FirstCounter, 0] = Values.verticalFieldBorder;
                TotalField[Values.FirstCounter, Values.maxFieldCoulum - 1] = Values.verticalFieldBorder;
            }
            for (Values.FirstCounter = 1; Values.FirstCounter < Values.maxFieldRow - 1; Values.FirstCounter++)
            {
                for (Values.SecondCounter = 1; Values.SecondCounter < Values.maxFieldCoulum - 1; Values.SecondCounter++)
                {
                    TotalField[Values.FirstCounter, Values.SecondCounter] = Values.fieldCell;
                }
            }
        }
    }
}
