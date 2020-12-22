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

        public static Accounts[] accounts;
        private int numbersAccounts;

        private int typeCard;
        private int numberCard;
        private int numberCardForArray;

        private bool wrongAccount;
        private bool rightAccount;
        private bool credit;
        private bool wrongLinkCard;
        private bool unknownKey;

        private int numbersCards;
        private int idCard;
        private int[] someCards;

        private double addMoney;
        private double getMoney;
        private double transitMoney;
        private int numberAccountForTrans;

        private string recipientName;
        private string recipientSurname;
        private string recipientLastname;
        private string recipientAccountNumber;
        private int[] arrayRecipientNumber;

        public static int TypeTransition { get; set; }
        public static int SurgeryConditon { get; set; }
        public static int FunctionNumber { get; set; }

        public void CreatAccounts()
        {
            WriteLine("How mach do you want accounts?");

            while (!int.TryParse(ReadLine(), out numbersAccounts))
            {
                Output.InformMistake();
            }

            accounts = new Accounts[numbersAccounts];

            for (int counter = 0; counter < numbersAccounts; counter++)
            {
                accounts[counter] = new Accounts();
            }
        }

        public void LinkDebitCards()
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
                    DebitCard.DebitCards = new int[numbersCards];

                    WriteLine("Choose account for debit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > accounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        wrongLinkCard = true;
                    }
                    else
                    {
                        DebitCard.DebitCards[counter] = idCard - 1;
                        accounts[idCard - 1].Money = 0;
                        wrongLinkCard = false;
                    }
                }
            }
            while (wrongLinkCard);
        }

        public void LinkKreditCards()
        {
            do
            {
                WriteLine("Choose how mach you want have credit card. ");

                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    Output.InformMistake();
                }

                Clear();

                for (int counter = 0; counter < numbersCards; counter++)
                {
                    KreditCard.KreditCards = new int[numbersCards];

                    WriteLine("Choose  account for credit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > accounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        wrongLinkCard = true;
                    }
                    else
                    {
                        KreditCard.KreditCards[counter] = idCard - 1;
                        accounts[idCard - 1].Money = 0;
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
                accounts[someCards[numberCardForArray]].Money += addMoney;

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

            CheckKredit();

            CheckRightAccount();

            if (rightAccount)
            {
                if (credit)
                {
                    WriteLine("You  have  unsecured loan on your accounts. ");
                }
                else
                {
                    if (getMoney > accounts[someCards[numberCardForArray]].Money && someCards == DebitCard.DebitCards)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        accounts[someCards[numberCardForArray]].Money -= getMoney;

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

                WriteLine($"In Your accont { accounts[someCards[numberCardForArray]].Money }$.");
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

            WriteLine("Choose acount, which you want to transfer money.");

            while (!int.TryParse(ReadLine(), out numberAccountForTrans))
            {
                Output.InformMistake();
            }

            Clear();

            CheckTypeCard();

            CheckKredit();

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
                    if (accounts[DebitCard.DebitCards[numberCardForArray]].Money < transitMoney)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        if (wrongAccount == false)
                        {
                            accounts[KreditCard.KreditCards[numberCardForArray]].Money -= transitMoney;
                            accounts[numberAccountForTrans - ConvertToArrayStyle].Money += transitMoney;

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

            CheckKredit();

            CheckRightAccount();

            if (rightAccount)
            {
                if (accounts[someCards[numberCardForArray]].Money < transitMoney && someCards == DebitCard.DebitCards)
                {
                    WriteLine("You dont have enough money on account.  ");
                }
                else
                {
                    accounts[someCards[numberCardForArray]].Money -= transitMoney;

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
                someCards = DebitCard.DebitCards;
            }
            else if (typeCard == (int)TypeCards.Credit)
            {
                someCards = KreditCard.KreditCards;
            }
        }

        public void CheckKredit()
        {
            for (int counter = 0; counter < accounts.Length; counter++)
            {
                credit = accounts[counter].Money < 0;

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
            if (someCards == DebitCard.DebitCards)
            {
                for (int counter = 0; counter < someCards.Length; counter++)
                {
                    if (numberAccountForTrans == someCards[counter])
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

        public void ChooseCard()
        {
            Output.ShowTypeCard();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        typeCard = (int)TypeCards.Debit;
                        unknownKey = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        typeCard = (int)TypeCards.Credit;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);

            Clear();

            WriteLine("Choose number of card");

            while (!int.TryParse(ReadLine(), out numberCard))
            {
                Output.InformMistake();
            }

            numberCardForArray = numberCard - ConvertToArrayStyle;
        }
    }
}
