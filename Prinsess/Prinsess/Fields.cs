using GameFunctions;

namespace GameField
{
    public class Field
    {
        public const int MaxFieldCoulum = 12;
        public const int MaxFieldRow = 12;

        public const int MaxGameCoulum = 11;
        public const int MaxGameRow = 11;

        public const int MinGameCoulum = 1;
        public const int MinGameRow = 1;

        public const string HorizontaFieldlBorder = "_";
        public const string VerticalFieldBorder = "|";
        public const string FieldCell = "♠";
        public string[,] TotalField { get; set; }

        public Field()
        {
            TotalField = new string[MaxFieldRow, MaxFieldCoulum];
        }

        public void CreateField()
        {
            for (GameFunction.FirstCounter = 0; GameFunction.FirstCounter < MaxFieldRow; GameFunction.FirstCounter++)
            {
                TotalField[0, GameFunction.FirstCounter] = HorizontaFieldlBorder;
                TotalField[MaxFieldRow - 1, GameFunction.FirstCounter] = HorizontaFieldlBorder;
            }
            for (GameFunction.FirstCounter = 1; GameFunction.FirstCounter < MaxFieldCoulum - 1; GameFunction.FirstCounter++)
            {
                TotalField[GameFunction.FirstCounter, 0] = VerticalFieldBorder;
                TotalField[GameFunction.FirstCounter, MaxFieldCoulum - 1] = VerticalFieldBorder;
            }
            for (GameFunction.FirstCounter = 1; GameFunction.FirstCounter < MaxFieldRow - 1; GameFunction.FirstCounter++)
            {
                for (GameFunction.SecondCounter = 1; GameFunction.SecondCounter < MaxFieldCoulum - 1; GameFunction.SecondCounter++)
                {
                    TotalField[GameFunction.FirstCounter, GameFunction.SecondCounter] = FieldCell;
                }
            }
        }
    }
}
