using System;
using System.Collections.Generic;

namespace Observer
{
    internal class CustomObserver : Observer
    {
        #region Public Methods

        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }

        #endregion Public Methods
    }

    internal class EmployeeObserver : Observer
    {
        #region Public Methods

        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }

        #endregion Public Methods
    }

    internal abstract class Observer
    {
        #region Public Methods

        public abstract void Update();

        #endregion Public Methods
    }

    internal class ProductManager
    {
        #region Private Fields

        private List<Observer> _observers = new List<Observer>();

        #endregion Private Fields

        #region Public Methods

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        #endregion Public Methods

        #region Private Methods

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        #endregion Private Methods
    }

    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            var customerObserver = new CustomObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
        }

        #endregion Private Methods
    }
}