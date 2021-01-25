using static System.Console;

namespace ITBank_2._0
{
    public class Card
    {
        public void AddMoney()
        {
            BankStorage.AccountsScore[Bank.SomeCards[Bank.numberCard]] += Bank.money;

            Output.LoadingInform();
        }

        public void GetMoney()
        {
            BankStorage.AccountsScore[Bank.SomeCards[Bank.numberCard]] -= Bank.money;

            Output.LoadingInform();
        }

        public void ShowMoney()
        {
            Output.LoadingInform();

            WriteLine($"In Your accont { BankStorage.AccountsScore[Bank.SomeCards[Bank.numberCard]] }$.");
        }

        public void TransitMoney()
        {
            BankStorage.AccountsScore[BankStorage.CreditCards[Bank.numberCard]] -= Bank.money;
            BankStorage.AccountsScore[Bank.accountForTransit] += Bank.money;

            Output.LoadingInform();
        }

        public void TransitMoneyOhterAccount()
        {
            BankStorage.AccountsScore[Bank.SomeCards[Bank.numberCard]] -= Bank.money;

            Output.LoadingInform();
        }
    }
}

