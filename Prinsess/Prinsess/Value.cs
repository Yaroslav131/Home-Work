namespace GameValues
{
    public class Values
    {
        //Field.       
        public const int MaxFieldCoulum = 12;
        public const int MaxFieldRow = 12;

        public const int MaxGameCoulum = 11;
        public const int MaxGameRow = 11;

        public const int MinGameCoulum = 1;
        public const int MinGameRow = 1;

        public const string HorizontaFieldlBorder = "_";
        public const string VerticalFieldBorder = "|";
        public const string FieldCell = "♠";

        //Prinsess.
        public const string PrinsessAvatar = "P";
        public const int PrinsessPossitionOx = 10;
        public const int PrinsessPossitionOy = 10;
        //Hero.
        public static int HitPoint { get; set; } = 10;
        public const string HeroAvatar = "H";

        public const int HeroStep = 1;
        public const int HeroStartOx = 1;
        public const int HeroStartOy = 1;
        public static int Ox { get; set; } = HeroStartOx;
        public static int Oy { get; set; } = HeroStartOy;

        //Mins.
        public const string MineAvatar = "¤";
        public static int MinsNumbers { get; set; } = 10;
        public const int MaxDamage = 10;
        public const int MinDamage = 1;

        //Game.
        public static int FirstCounter { get; set; }
        public static int SecondCounter { get; set; }
        public static bool UnknownKey { get; set; }
        public static bool ExitGameСycle { get; set; }
        public static bool ExitGame { get; set; }
    }
}
