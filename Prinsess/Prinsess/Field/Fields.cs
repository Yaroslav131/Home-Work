using FieldValues;
using GameValues;
namespace GameField
{
    public class Field
    {
        public string[,] TotalField { get; set; }

        public Field()
        {
            TotalField = new string[FieldValue.MaxFieldRow, FieldValue.MaxFieldCoulum];
        }

        public void CreateField()
        {
            for (GameValue.FirstCounter = 0; GameValue.FirstCounter < FieldValue.MaxFieldRow; GameValue.FirstCounter++)
            {
                TotalField[0, GameValue.FirstCounter] = FieldValue.HorizontaFieldlBorder;
                TotalField[FieldValue.MaxFieldRow - 1, GameValue.FirstCounter] = FieldValue.HorizontaFieldlBorder;
            }
            for (GameValue.FirstCounter = 1; GameValue.FirstCounter < FieldValue.MaxFieldCoulum - 1; GameValue.FirstCounter++)
            {
                TotalField[GameValue.FirstCounter, 0] = FieldValue.VerticalFieldBorder;
                TotalField[GameValue.FirstCounter, FieldValue.MaxFieldCoulum - 1] = FieldValue.VerticalFieldBorder;
            }
            for (GameValue.FirstCounter = 1; GameValue.FirstCounter < FieldValue.MaxFieldRow - 1; GameValue.FirstCounter++)
            {
                for (GameValue.SecondCounter = 1; GameValue.SecondCounter < FieldValue.MaxFieldCoulum - 1; GameValue.SecondCounter++)
                {
                    TotalField[GameValue.FirstCounter, GameValue.SecondCounter] = FieldValue.FieldCell;
                }
            }
        }
    }
}
