namespace HeroValues
{
    public static class HeroValue
    {
        public static int HitPoint { get; set; } = 10;
        public const string HeroAvatar = "H";
        public const int HeroStep = 1;
        public const int HeroStartOx = 1;
        public const int HeroStartOy = 1;
        public static int Ox { get; set; } = HeroStartOx;
        public static int Oy { get; set; } = HeroStartOy;
    }
}
