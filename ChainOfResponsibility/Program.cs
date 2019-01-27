using System;

namespace ChainOfResponsibility
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            Manager manager = new Manager();
            VoicePresident voicePresident = new VoicePresident();
            President president = new President();

            manager.SetSuccessor(voicePresident);
            voicePresident.SetSuccessor(president);

            Expense expense = new Expense {Detail = "Training", Amount = 110};
            Console.ReadLine();
        }

        #endregion Private Methods
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase _successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            _successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        #region Overrides of ExpenseHandlerBase

        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }

        #endregion
    }

    class VoicePresident : ExpenseHandlerBase
    {
        #region Overrides of ExpenseHandlerBase

        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("Voice President handled the expense!");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }

        #endregion
    }

    class President : ExpenseHandlerBase
    {
        #region Overrides of ExpenseHandlerBase

        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
            else if (_successor != null)
            {
                _successor.HandleExpense(expense);
            }
        }

        #endregion
    }
}