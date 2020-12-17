using BankAccount;
using BankAccounts;
using BankCards;
using OutputLine;
using System;
using static System.Console;

namespace BankFunctions
{
    public class BankFunction
    {
        Cards cards = new Cards();

        public enum CardFunctions
        {
            AddMoney = 1,
            GetMoney,
            ShowMoney,
            TransitMoney,
        }

        public enum TypeTransit
        {
            TransitMoney = 1,
            TransitMoneyOhterAccount
        }

        public enum SurgeryConditons
        {
            Yes = 1,
            No
        }

        public static int TypeTransition { get; set; }
        public static int SurgeryConditon { get; set; }
        public static int FunctionNumber { get; set; }
        public static bool UnknownKey { get; set; }

        private int numbersAccounts;
        private int numbersCards;
        private int idCard;
        private bool wrongLinkCard;

        public void CreatAccuonts()
        {
            WriteLine("How mach do you want accounts?");

            while (!int.TryParse(ReadLine(), out numbersAccounts))
            {
                Output.InformMistake();
            }

            Accounts.UserAccounts = new Account[numbersAccounts];

            for (int i = 0; i < numbersAccounts; i++)
            {
                Accounts.UserAccounts[i] = new Account();
            }
        }

        public void ChooseFunction()
        {
            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        FunctionNumber = (int)CardFunctions.AddMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        FunctionNumber = (int)CardFunctions.GetMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        FunctionNumber = (int)CardFunctions.ShowMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        FunctionNumber = (int)CardFunctions.TransitMoney;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }

        public void LinkCards()
        {
            do
            {
                WriteLine("Choose how mach you want have debit cards. ");

                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    Output.InformMistake();
                }

                Clear();

                for (int counter = 0; counter < numbersCards; counter++)
                {
                    cards.DebitsCards = new int[numbersCards];

                    WriteLine("Choose account for debit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > Accounts.UserAccounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        wrongLinkCard = true;
                    }
                    else
                    {
                        cards.DebitsCards[counter] = idCard - 1;
                        Accounts.UserAccounts[idCard - 1].Money = 0;
                        wrongLinkCard = false;
                    }
                }

                Clear();

                WriteLine("Choose how mach you want have credit card. ");

                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    Output.InformMistake();
                }

                Clear();

                for (int counter = 0; counter < numbersCards; counter++)
                {
                    cards.KreditsCards = new int[numbersCards];

                    WriteLine("Choose  account for credit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > Accounts.UserAccounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        wrongLinkCard = true;
                    }
                    else
                    {
                        cards.KreditsCards[counter] = idCard - 1;
                        Accounts.UserAccounts[idCard - 1].Money = 0;
                        wrongLinkCard = false;
                    }
                }

                if (wrongLinkCard == true)
                {
                    WriteLine("We have problem with registration,try again.");
                }
            }
            while (wrongLinkCard);
        }

        public void ChooseTypeTransitoin()
        {
            Output.ShowTypeTransitions();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        TypeTransition = (int)TypeTransit.TransitMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        TypeTransition = (int)TypeTransit.TransitMoneyOhterAccount;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }

        public void ChooseSurgery()
        {

            Output.ShowSurgery();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        SurgeryConditon = (int)SurgeryConditons.Yes;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        SurgeryConditon = (int)SurgeryConditons.No;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }
    }
}
