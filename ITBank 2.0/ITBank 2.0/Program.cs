using static System.Console;

namespace ITBank_2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {

            BankFunctions bankFunctions = new BankFunctions();

            WriteLine("Wellcom to the ITBank.");

            bankFunctions.CreatAccounts();

            Clear();

            bankFunctions.LinkDebitCards();

            Clear();

            bankFunctions.LinkKreditCards();

            do
            {
                Clear();

                Output.ShowFunctions();

                bankFunctions.ChooseFunction();

                switch (BankFunctions.FunctionNumber)
                {
                    case (int)BankFunctions.CardFunctions.AddMoney:

                        Clear();

                        bankFunctions.ChooseCard();

                        Clear();

                        bankFunctions.AddMoney();

                        bankFunctions.ChooseSurgery();

                        break;

                    case (int)BankFunctions.CardFunctions.GetMoney:

                        Clear();

                        bankFunctions.ChooseCard();

                        Clear();

                        bankFunctions.GetMoney();

                        bankFunctions.ChooseSurgery();

                        break;

                    case (int)BankFunctions.CardFunctions.ShowMoney:

                        Clear();

                        bankFunctions.ChooseCard();

                        Clear();

                        bankFunctions.ShowMoney();

                        bankFunctions.ChooseSurgery();

                        break;

                    case (int)BankFunctions.CardFunctions.TransitMoney:

                        Clear();

                        bankFunctions.ChooseTypeTransitoin();

                        Clear();

                        bankFunctions.ChooseCard();

                        if (BankFunctions.TypeTransition == (int)BankFunctions.TypeTransits.TransitMoney)
                        {
                            bankFunctions.TransitMoney();
                        }
                        else if (BankFunctions.TypeTransition == (int)BankFunctions.TypeTransits.TransitMoneyOhterAccount)
                        {
                            bankFunctions.TransitMoneyOhterAccount();
                        }

                        bankFunctions.ChooseSurgery();

                        break;

                    default:

                        Clear();

                        WriteLine("We don't have this operatioin,try again.");

                        bankFunctions.ChooseSurgery();

                        break;
                }
            }
            while (BankFunctions.SurgeryConditon == (int)BankFunctions.SurgeryConditons.Yes);
        }
    }
}


