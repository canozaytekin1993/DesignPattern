using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.CreditCalculatorBase = new After2018CreditCalculator();;
            customer.SaveCredit();

            customer.CreditCalculatorBase = new Beforo2018CreditCalculator(); ;
            customer.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Beforo2018CreditCalculator : CreditCalculatorBase
    {
        #region Overrides of CreditCalculatorBase

        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2018");
        }

        #endregion
    }

    class After2018CreditCalculator : CreditCalculatorBase
    {
        #region Overrides of CreditCalculatorBase

        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2018");
        }

        #endregion
    }

    class Customer
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manage business ");
        }
    }
}
