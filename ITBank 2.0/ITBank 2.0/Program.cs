using static System.Console;

namespace ITBank_2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            Card card = new Card();

            WriteLine("Wellcom to the ITBank.");

            bank.CreatAccounts();

            do
            {
                Clear();

                bank.LinkDebitCards();

                Clear();

                bank.LinkCreditCards();

                if (BankStorage.DebitCards.Length == 0 && BankStorage.CreditCards.Length == 0)
                {
                    WriteLine("You don't have card in this bank");

                    bank.RecreateCard();
                }
            }
            while (Bank.RebuildConditon);

            if (!(BankStorage.DebitCards.Length == 0 && BankStorage.CreditCards.Length == 0))
            {
                do
                {
                    Clear();

                    bank.ChooseFunction();

                    switch (Bank.FunctionNumber)
                    {
                        case (int)Bank.CardFunctions.AddMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            bank.SetSum();

                            Clear();

                            if (Bank.RightAccount)
                            {
                                card.AddMoney();
                            }

                            bank.ChooseSurgery();

                            break;

                        case (int)Bank.CardFunctions.GetMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightAccount && !Bank.Credit && !Bank.NegativeBallance)
                            {
                                bank.SetSum();

                                if ( !Bank.NegativeBallance)
                                {
                                    card.GetMoney();
                                }
                            }

                            bank.ChooseSurgery();

                            break;

                        case (int)Bank.CardFunctions.ShowMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightAccount)
                            {
                                card.ShowMoney();
                            }

                            bank.ChooseSurgery();

                            break;

                        case (int)Bank.CardFunctions.TransitMoney:

                            Clear();

                            bank.ChooseTypeTransitoin();

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightAccount && !Bank.Credit )
                            {
                                bank.SetSum();

                                if (Bank.TypeTransition == (int)Bank.TypeTransits.TransitMoney && !Bank.NegativeBallance)
                                {
                                    Clear();

                                    bank.ChooseAccountForTransit();

                                    if (!Bank.WrongAccount)
                                    {
                                        card.TransitMoney();
                                    }                                    
                                }
                                else if (Bank.TypeTransition == (int)Bank.TypeTransits.TransitMoneyOhterAccount && !Bank.NegativeBallance)
                                {
                                    Clear();

                                    bank.GetRecipientData();

                                    card.TransitMoneyOhterAccount();
                                }
                            }

                            bank.ChooseSurgery();

                            break;

                        default:

                            Clear();

                            WriteLine("We don't have this operatioin,try again.");

                            bank.ChooseSurgery();

                            break;
                    }
                }
                while (Bank.SurgeryConditon == (int)Bank.SurgeryConditons.Yes);

                Clear();
            }
        }
    }
}