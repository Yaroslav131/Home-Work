using static System.Console;

namespace ITBank_2._0
{
    public static class Output
    {
        public static void InformMistake()
        {
            WriteLine("You have mistake, write correctly.");
        }

        public static void ShowFunctions()
        {
            WriteLine("What you want to do?" +
                     "\n1)Add money to acount." +
                     "\n2)Get Money from acount." +
                     "\n3)Look score." +
                     "\n4)Transition money.");
        }

        public static void ShowTypeTransitions()
        {
            WriteLine("Where are you want transit your money" +
                "\n1)Your accounts." +
                "\n2)Other accounts.");
        }

        public static void ShowSurgery()
        {
            WriteLine("Would you like to do another surgery?" +
               "\n1)Enter." +
               "\n2)Esc.");
        }

        public static void ShowTypeCard()
        {
            WriteLine("Choose card " +
             "\n1)Debit." +
             "\n2)Kredit.");
        }

    }
}
