namespace GameValues
{
    public class Values
    {
        //Field.       
        public const int maxFieldCoulum = 12;
        public const int maxFieldRow = 12;

        public const int maxGameCoulum = 11;
        public const int maxGameRow = 11;

        public const int minGameCoulum = 1;
        public const int minGameRow = 1;

        public const string horizontaFieldlBorder = "_";
        public const string verticalFieldBorder = "|";
        public const string fieldCell = "♠";

        //Prinsess.
        public const string prinsessAvatar = "P";
        public const int prinsessPossitionOx = 10;
        public const int prinsessPossitionOy = 10;
        //Hero.
        public static int HitPoint { get; set; } = 10;
        public const string heroAvatar = "H";

        public const int heroStep = 1;
        public const int heroStartOx = 1;
        public const int heroStartOy = 1;
        public static int Ox { get; set; } = heroStartOx;
        public static int Oy { get; set; } = heroStartOy;

        //Mins.
        public const string MineAvatar = "¤";
        public static int MinsNumbers { get; set; } = 10;
        public const int maxDamage = 10;
        public const int minDamage = 1;

        //Game.
        public static int FirstCounter { get; set; }
        public static int SecondCounter { get; set; }
        public static bool UnknownKey { get; set; }
        public static bool ExitGameСycle { get; set; }
        public static bool ExitGame { get; set; }
    }
}
