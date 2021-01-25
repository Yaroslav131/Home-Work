using System;
using static System.Console;

namespace ITBank_2._0
{
    public class Bank
    {
        public enum CardFunctions
        {
            AddMoney = 1,
            GetMoney,
            ShowMoney,
            TransitMoney,
        }

        public enum TypeCards
        {
            Debit = 1,
            Credit
        }

        public enum TypeTransits
        {
            TransitMoney = 1,
            TransitMoneyOhterAccount
        }

        public enum SurgeryConditons
        {
            Yes = 1,
            No
        }

        private long numbersAccounts;
        private long numbersCards;
        private int typeCard;
        private int idCard;
        private bool wrongLinkCard;
        private bool unknownKey;

        public static bool NegativeBallance { get; set; }
        public static bool WrongAccount { get; set; }
        public static bool RightAccount { get; set; }
        public static bool Credit { get; set; }
        public static int TypeTransition { get; set; }
        public static int SurgeryConditon { get; set; }
        public static int FunctionNumber { get; set; }
        public static bool RebuildConditon { get; set; }
        public static int[] someCards { get; set; }

        internal static double money;
        internal static long accountForTransit;
        internal static long numberCard;

        private string recipientName;
        private string recipientSurname;
        private string recipientLastname;
        private string recipientAccountNumber;
        private int[] arrayRecipientNumber;

        private const int MaxLenghtPassword = 20;
        private const int ConvertToArrayStyle = 1;

        public Bank()
        {
            RightAccount = false;
            WrongAccount = false;
        }

        public void CreatAccounts()
        {
            WriteLine("How mach do you want accounts?");

            while (!long.TryParse(ReadLine(), out numbersAccounts) || numbersAccounts <= 0)
            {
                Clear();

                Output.InformMistake();
            }

            BankStorage.AccountsScore = new double[numbersAccounts];
        }

        public void LinkDebitCards()
        {
            do
            {
                WriteLine("Choose how mach you want have debit cards. ");

                while (!long.TryParse(ReadLine(), out numbersCards))
                {
                    Clear();

                    Output.InformMistake();
                }

                BankStorage.DebitCards = new int[numbersCards];

                if (numbersCards == 0)
                {
                    wrongLinkCard = false;
                }
                else
                {
                    for (int counter = 0; counter < numbersCards; counter++)
                    {

                        WriteLine("Choose account for debit card. ");

                        while (!int.TryParse(ReadLine(), out idCard) || idCard <= 0)
                        {
                            Output.InformMistake();
                        }

                        idCard -= ConvertToArrayStyle;

                        if (idCard > BankStorage.AccountsScore.Length || idCard < 0)
                        {
                            Output.InformMistake();

                            wrongLinkCard = true;
                        }
                        else
                        {
                            BankStorage.DebitCards[counter] = idCard;
                            BankStorage.AccountsScore[idCard] = 0;
                            wrongLinkCard = false;
                        }
                    }
                }
            }
            while (wrongLinkCard);
        }

        public void LinkCreditCards()
        {
            do
            {
                WriteLine("Choose how mach you want have credit card. ");

                while (!long.TryParse(ReadLine(), out numbersCards))
                {
                    Clear();

                    Output.InformMistake();
                }

                BankStorage.CreditCards = new int[numbersCards];

                if (numbersCards == 0)
                {
                    wrongLinkCard = false;
                }
                else
                {
                    for (int counter = 0; counter < numbersCards; counter++)
                    {
                        WriteLine("Choose  account for credit card. ");

                        while (!int.TryParse(ReadLine(), out idCard) || idCard <= 0)
                        {
                            Clear();

                            Output.InformMistake();
                        }

                        idCard -= ConvertToArrayStyle;

                        if (idCard > BankStorage.AccountsScore.Length || idCard < 0)
                        {
                            Output.InformMistake();

                            wrongLinkCard = true;
                        }
                        else
                        {
                            BankStorage.CreditCards[counter] = idCard;
                            BankStorage.AccountsScore[idCard] = 0;
                            wrongLinkCard = false;
                        }
                    }

                    if (wrongLinkCard == true)
                    {
                        WriteLine("We have problem with registration,try again.");
                    }
                }
            }
            while (wrongLinkCard);
        }

        public void ChooseFunction()
        {
            do
            {
                Output.ShowFunctions();

                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        FunctionNumber = (int)CardFunctions.AddMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        FunctionNumber = (int)CardFunctions.GetMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        FunctionNumber = (int)CardFunctions.ShowMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        FunctionNumber = (int)CardFunctions.TransitMoney;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
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
                        TypeTransition = (int)TypeTransits.TransitMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        TypeTransition = (int)TypeTransits.TransitMoneyOhterAccount;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
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
                        unknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        SurgeryConditon = (int)SurgeryConditons.No;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
        }

        public void RecreateCard()
        {
            Output.ShowCreateOptions();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        RebuildConditon = true;
                        unknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        RebuildConditon = false;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
        }

        public void ChooseCard()
        {
            do
            {
                Output.ShowTypeCard();

                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        typeCard = (int)TypeCards.Debit;
                        unknownKey = false;

                        if (BankStorage.DebitCards.Length == 0)
                        {
                            Clear();

                            WriteLine("You don't have card this type ");

                            unknownKey = true;
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        typeCard = (int)TypeCards.Credit;
                        unknownKey = false;

                        if (BankStorage.CreditCards.Length == 0)
                        {
                            Clear();

                            WriteLine("You don't have  card this type ");

                            unknownKey = true;
                        }
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);

            Clear();

            WriteLine("Choose number of card");

            while (!long.TryParse(ReadLine(), out numberCard))
            {
                Output.InformMistake();
            }

            numberCard -= ConvertToArrayStyle;

            CheckTypeCard();

            CheckRightAccount();

            CheckCredit();
        }

        public void ChooseAccountForTransit()
        {
            WriteLine("Choose account, which you want to transfer money.");

            while (!long.TryParse(ReadLine(), out accountForTransit))
            {
                Output.InformMistake();
            }

            accountForTransit -= ConvertToArrayStyle;

            CheckNumberAccountForTrans();
        }

        public void SetSum()
        {
            WriteLine("How match money?");

            while (!double.TryParse(ReadLine(), out money) || money < 0)
            {
                Output.InformMistake();
            }

            if (FunctionNumber== (int)CardFunctions.GetMoney|| FunctionNumber == (int)CardFunctions.TransitMoney)
            {
                CheckNegativeBallance();
            }
        }

        public void GetRecipientData()
        {
            WriteLine("Write name of a recipient.");

            recipientName = ReadLine();

            WriteLine("Write surname of a recipient.");

            recipientSurname = ReadLine();

            WriteLine("Write lastname of a recipient.");

            recipientLastname = ReadLine();

            WriteLine("Write account number of a recipient (20 numbers). ");

            do
            {
                recipientAccountNumber = ReadLine();
                char[] arrScoreNumChar = recipientAccountNumber.ToCharArray();
                arrayRecipientNumber = new int[arrScoreNumChar.Length];

                for (int counter = 0; counter < arrayRecipientNumber.Length; counter++)
                {
                    while (!int.TryParse(arrScoreNumChar[counter].ToString(), out arrayRecipientNumber[counter]) || money < 0)
                    {
                        Output.InformMistake();
                    }
                }

                if (arrayRecipientNumber.Length < MaxLenghtPassword || arrayRecipientNumber.Length > MaxLenghtPassword)
                {
                    Output.InformMistake();
                }
            }
            while (arrayRecipientNumber.Length < MaxLenghtPassword || arrayRecipientNumber.Length > MaxLenghtPassword);
        }

        public void CheckTypeCard()
        {
            if (typeCard == (int)TypeCards.Debit)
            {
                someCards = BankStorage.DebitCards;
            }
            else if (typeCard == (int)TypeCards.Credit)
            {
                someCards = BankStorage.CreditCards;
            }
        }

        public void CheckCredit()
        {
            for (int counter = 0; counter < BankStorage.AccountsScore.Length; counter++)
            {
                Credit = BankStorage.AccountsScore[counter] < 0;

                if (Credit == true)
                {
                    Clear();

                    WriteLine("You  have  unsecured loan on your accounts. ");

                    break;
                }
            }
        }

        public void CheckRightAccount()
        {
            for (int counter = 0; counter < someCards.Length; counter++)
            {
                RightAccount = numberCard == counter;

                if (RightAccount == true)
                {
                    break;
                }
            }

            if (RightAccount == false)
            {
                WriteLine("Wrong number of card");
            }
        }

        public void CheckNumberAccountForTrans()
        {
            if (someCards == BankStorage.CreditCards)
            {
                for (int counter = 0; counter < someCards.Length; counter++)
                {
                    if (accountForTransit != someCards[counter] - ConvertToArrayStyle)
                    {
                        WrongAccount = true;

                        Output.InformMistake();
                    }
                }
            }
        }

        public void CheckNegativeBallance()
        {
            if (Bank.money > BankStorage.AccountsScore[Bank.someCards[Bank.numberCard]] && Bank.someCards == BankStorage.DebitCards)
            {
                NegativeBallance = true;

                Clear();

                WriteLine("You dont have enough money on account.");
            }
        }
    }
}
