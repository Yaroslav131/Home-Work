using GameValues;
namespace GameField
{
    public class Field
    {
        public string[,] TotalField { get; set; }

        public Field()
        {
            TotalField = new string[Values.MaxFieldRow, Values.MaxFieldCoulum];
        }

        public void CreateField()
        {
            for (Values.FirstCounter = 0; Values.FirstCounter < Values.MaxFieldRow; Values.FirstCounter++)
            {
                TotalField[0, Values.FirstCounter] = Values.HorizontaFieldlBorder;
                TotalField[Values.MaxFieldRow - 1, Values.FirstCounter] = Values.HorizontaFieldlBorder;
            }
            for (Values.FirstCounter = 1; Values.FirstCounter < Values.MaxFieldCoulum - 1; Values.FirstCounter++)
            {
                TotalField[Values.FirstCounter, 0] = Values.VerticalFieldBorder;
                TotalField[Values.FirstCounter, Values.MaxFieldCoulum - 1] = Values.VerticalFieldBorder;
            }
            for (Values.FirstCounter = 1; Values.FirstCounter < Values.MaxFieldRow - 1; Values.FirstCounter++)
            {
                for (Values.SecondCounter = 1; Values.SecondCounter < Values.MaxFieldCoulum - 1; Values.SecondCounter++)
                {
                    TotalField[Values.FirstCounter, Values.SecondCounter] = Values.FieldCell;
                }
            }
        }
    }
}
