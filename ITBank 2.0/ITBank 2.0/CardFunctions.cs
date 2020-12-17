using BankFunctions;
using OutputLine;
using BankAccounts;
using BankCards;
using System;
using System.Threading;
using static System.Console;

namespace BankCards
{
    public class CardFunctions: Cards
    {
        Accounts accounts = new Accounts();

        public enum TypeCards
        {
            Debit = 1,
            Credit
        }

        private const int ConverToArrayStyle = 1;

        private double addMoney;
        private double getMoney;
        private double transitMoney;
        private int numberAccountForTrans;

        private string recipientName;
        private string recipientSurname;
        private string recipientLastname;
        private string recipientAccountNumber;
        private int[] arrayRecipientNumber;

        private int typeCard;
        private int numberCard;
        private int numberCardForArray;

        private bool wrongAccount;
        private bool rightAccount;
        private bool credit;

        private int[] someCards;

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
                        BankFunction.UnknownKey = false;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        typeCard = (int)TypeCards.Credit;
                        BankFunction.UnknownKey = false;
                        break;

                    default:
                        BankFunction.UnknownKey = true;
                        break;
                }
            }
            while (BankFunction.UnknownKey);

            Clear();

            WriteLine("Choose number of card");

            while (!int.TryParse(ReadLine(), out numberCard))
            {
                Output.InformMistake();
            }

            numberCardForArray = numberCard - ConverToArrayStyle;
        }

        public void AddMoney()
        {
            WriteLine("How match do you want add money?");

            while (!double.TryParse(ReadLine(), out addMoney) || addMoney < 0)
            {
                Output.InformMistake();
            }

            Clear();

            CheckConditionsOpperations();

            if (rightAccount)
            {
                Accounts.UserAccounts[someCards[numberCardForArray]].Money += addMoney;

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

            CheckConditionsOpperations();

            if (rightAccount)
            {
                if (credit)
                {
                    WriteLine("You  have  unsecured loan on your accounts. ");
                }
                else
                {
                    if (getMoney > Accounts.UserAccounts[someCards[numberCardForArray]].Money || someCards == DebitsCards)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        Accounts.UserAccounts[someCards[numberCardForArray]].Money -= getMoney;

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

            CheckConditionsOpperations();

            if (rightAccount)
            {
                WriteLine("Loading...");

                Thread.Sleep(2500);

                Clear();

                WriteLine("Operation was a success.");

                WriteLine($"In Your accont {Accounts.UserAccounts[someCards[numberCardForArray]].Money }$.");
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

            CheckConditionsOpperations();

            if (rightAccount)
            {
                if (credit)
                {
                    WriteLine("You have unsecured loan on your accounts. ");
                }
                else
                {
                    if (Accounts.UserAccounts[DebitsCards[numberCardForArray]].Money < transitMoney)
                    {
                        WriteLine("You dont have enough money on account.");
                    }
                    else
                    {
                        if (wrongAccount == false)
                        {
                            Accounts.UserAccounts[KreditsCards[numberCardForArray]].Money -= transitMoney;
                            Accounts.UserAccounts[numberAccountForTrans - ConverToArrayStyle].Money += transitMoney;

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

            CheckConditionsOpperations();

            if (rightAccount)
            {
                if (Accounts.UserAccounts[someCards[numberCardForArray]].Money < transitMoney && someCards ==DebitsCards)
                {
                    WriteLine("You dont have enough money on account.  ");
                }
                else
                {
                    Accounts.UserAccounts[someCards[numberCardForArray]].Money -= transitMoney;

                    WriteLine("Loading...");

                    Thread.Sleep(2500);

                    WriteLine("Operation was a success.");
                }
            }
        }

        public void CheckConditionsOpperations()
        {
            if (typeCard == (int)TypeCards.Debit)
            {
                someCards = DebitsCards;
            }
            else if (typeCard == (int)TypeCards.Credit)
            {
                someCards = KreditsCards;
            }

            for (int counter = 0; counter < Accounts.UserAccounts.Length; counter++)
            {
                credit = Accounts.UserAccounts[counter].Money < 0;

                if (credit == true)
                {
                    break;
                }
            }

            for (int counter = 0; counter < someCards.Length; counter++)
            {
                rightAccount = numberCard == someCards[counter];

                if (rightAccount == true)
                {
                    break;
                }
            }

            if (someCards == DebitsCards)
            {
                for (int counter = 0; counter < someCards.Length; counter++)
                {
                    if (numberAccountForTrans - ConverToArrayStyle == someCards[counter])
                    {
                        wrongAccount = true;

                        break;
                    }
                }
            }
        }
    }
}
