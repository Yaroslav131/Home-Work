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
            for (int FirstCounter = 0; FirstCounter < MaxFieldRow; FirstCounter++)
            {
                TotalField[0, FirstCounter] = HorizontaFieldlBorder;
                TotalField[MaxFieldRow - 1, FirstCounter] = HorizontaFieldlBorder;
            }
            for (int FirstCounter = 1; FirstCounter < MaxFieldCoulum - 1; FirstCounter++)
            {
                TotalField[FirstCounter, 0] = VerticalFieldBorder;
                TotalField[FirstCounter, MaxFieldCoulum - 1] = VerticalFieldBorder;
            }
            for (int FirstCounter = 1; FirstCounter < MaxFieldRow - 1; FirstCounter++)
            {
                for (int SecondCounter = 1; SecondCounter < MaxFieldCoulum - 1; SecondCounter++)
                {
                    TotalField[FirstCounter, SecondCounter] = FieldCell;
                }
            }
        }
    }
}
