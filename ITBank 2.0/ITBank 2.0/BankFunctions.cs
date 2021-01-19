using System;
using System.Threading;
using static System.Console;

namespace ITBank_2._0
{
    public class BankFunctions
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

        private const int ConvertToArrayStyle = 1;

        private long numbersAccounts;

        private int typeCard;
        private long numberCard;
        private long numberCardForArray;
        private long numberAccountForTrans;

        private bool wrongAccount;
        private bool rightAccount;
        private bool credit;
        private bool wrongLinkCard;
        private bool unknownKey;

        private long numbersCards;
        private int idCard;
        private int[] someCards;

        private double addMoney;
        private double getMoney;
        private double transitMoney;

        private string recipientName;
        private string recipientSurname;
        private string recipientLastname;
        private string recipientAccountNumber;
        private int[] arrayRecipientNumber;

        public static int TypeTransition { get; set; }
        public static int SurgeryConditon { get; set; }
        public static bool RebuildConditon { get; set; } 
        public static int FunctionNumber { get; set; }

        public BankFunctions()
        {
            wrongAccount = false;
            RebuildConditon = false;
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

                        if (idCard > BankStorage.AccountsScore.Length || idCard < 1)
                        {
                            Output.InformMistake();

                            wrongLinkCard = true;
                        }
                        else
                        {
                            BankStorage.DebitCards[counter] = idCard - 1;
                            BankStorage.AccountsScore[idCard - 1] = 0;
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

                        if (idCard > BankStorage.AccountsScore.Length || idCard < 1)
                        {
                            Output.InformMistake();

                            wrongLinkCard = true;
                        }
                        else
                        {
                            BankStorage.CreditCards[counter] = idCard - 1;
                            BankStorage.AccountsScore[idCard - 1] = 0;
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

        public void AddMoney()
        {
            WriteLine("How match do you want add money?");

            while (!double.TryParse(ReadLine(), out addMoney) || addMoney < 0)
            {
                Output.InformMistake();
            }

            Clear();

            CheckTypeCard();

            CheckRightAccount();

            if (rightAccount)
            {
                BankStorage.AccountsScore[someCards[numberCardForArray]] += addMoney;

                WriteLine("Loading...");

                Thread.Sleep(2500);

                WriteLine("Operation was a success.");
            }
            else
            {
                WriteLine("Wrong number of card");
            }
        }

        public void GetMoney()
        {
            WriteLine("How match do you want get money?");

            while (!double.TryParse(ReadLine(), out getMoney) || getMoney < 0)
            {
                Output.InformMistake();
            }

            Clear();

            CheckTypeCard();

            CheckCredit();

            CheckRightAccount();

            if (rightAccount)
            {
                if (credit)
                {
                    WriteLine("You  have  unsecured loan on your accounts. ");
                }
                else
                {
                    if (getMoney > BankStorage.AccountsScore[someCards[numberCardForArray]] && someCards == BankStorage.DebitCards)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        BankStorage.AccountsScore[someCards[numberCardForArray]] -= getMoney;

                        WriteLine("Loading...");

                        Thread.Sleep(2500);

                        WriteLine("Operation was a success.");
                    }
                }
            }
            else
            {
                WriteLine("Wrong number of card");
            }
        }

        public void ShowMoney()
        {
            Clear();

            CheckTypeCard();

            CheckRightAccount();

            if (rightAccount)
            {
                WriteLine("Loading...");

                Thread.Sleep(2500);

                Clear();

                WriteLine("Operation was a success.");

                WriteLine($"In Your accont { BankStorage.AccountsScore[someCards[numberCardForArray]] }$.");
            }
            else
            {
                WriteLine("Wrong number of card");
            }
        }

        public void TransitMoney()
        {
            WriteLine("How match do you want transit money?");

            while (!double.TryParse(ReadLine(), out transitMoney) || transitMoney < 0)
            {

                Output.InformMistake();
            }

            Clear();

            WriteLine("Choose account, which you want to transfer money.");

            while (!long.TryParse(ReadLine(), out numberAccountForTrans))
            {
                Output.InformMistake();
            }

            Clear();

            CheckTypeCard();

            CheckCredit();

            CheckRightAccount();

            CheckNumberAccountForTrans();

            if (rightAccount)
            {
                if (credit)
                {
                    WriteLine("You have unsecured loan on your accounts. ");
                }
                else
                {
                    if (BankStorage.AccountsScore[someCards[numberCardForArray]] < transitMoney && someCards == BankStorage.DebitCards)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        if (wrongAccount == false)
                        {
                            BankStorage.AccountsScore[BankStorage.CreditCards[numberCardForArray]] -= transitMoney;
                            BankStorage.AccountsScore[numberAccountForTrans - ConvertToArrayStyle] += transitMoney;

                            WriteLine("Loading...");

                            Thread.Sleep(2500);

                            WriteLine("Operation was a success.");
                        }
                        else
                        {
                            Output.InformMistake();
                        }
                    }
                }
            }
            else
            {
                WriteLine("Wrong number of card");
            }
        }

        public void TransitMoneyOhterAccount()
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
                    while (!int.TryParse(arrScoreNumChar[counter].ToString(), out arrayRecipientNumber[counter]) || transitMoney < 0)
                    {
                        Output.InformMistake();
                    }
                }

                if (arrayRecipientNumber.Length < 20 || arrayRecipientNumber.Length > 20)
                {
                    Output.InformMistake();
                }
            }
            while (arrayRecipientNumber.Length < 20 || arrayRecipientNumber.Length > 20);

            Clear();

            WriteLine("How match do you want transit money?");

            while (!double.TryParse(ReadLine(), out transitMoney) || transitMoney < 0)
            {
                Output.InformMistake();
            }

            Clear();

            CheckTypeCard();

            CheckCredit();

            CheckRightAccount();

            if (rightAccount)
            {
                if (BankStorage.AccountsScore[someCards[numberCardForArray]] < transitMoney && someCards == BankStorage.DebitCards)
                {
                    WriteLine("You don't have enough money on account.  ");
                }
                else
                {
                    BankStorage.AccountsScore[someCards[numberCardForArray]] -= transitMoney;

                    WriteLine("Loading...");

                    Thread.Sleep(2500);

                    WriteLine("Operation was a success.");
                }
            }
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
                credit = BankStorage.AccountsScore[counter] < 0;

                if (credit == true)
                {
                    break;
                }
            }
        }

        public void CheckRightAccount()
        {
            for (int counter = 0; counter < someCards.Length; counter++)
            {
                rightAccount = numberCard - ConvertToArrayStyle == counter;

                if (rightAccount == true)
                {
                    break;
                }
            }
        }

        public void CheckNumberAccountForTrans()
        {
            if (someCards == BankStorage.CreditCards)
            {
                for (int counter = 0; counter < someCards.Length; counter++)
                {
                    if (numberAccountForTrans != someCards[counter])
                    {
                        wrongAccount = true;

                        break;
                    }
                }
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

            Output.ShowOptions();

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

                            WriteLine("You don't have  card of this type ");

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

                            WriteLine("You don't have  card of this type ");

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

            numberCardForArray = numberCard - ConvertToArrayStyle;
        }
    }
}
