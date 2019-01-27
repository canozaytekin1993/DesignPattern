using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            BuyStock buyStock = new BuyStock(stock);
            SellStock sellStock = new SellStock(stock);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            Console.ReadLine();
        }
    }

    class Stock
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stok : {0} , {1} bought!", _name, _quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stok : {0},{1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private Stock _stock;

        public BuyStock(Stock stock)
        {
            _stock = stock;
        }

        public void Execute()
        {
            _stock.Buy();
        }
    }

    class SellStock : IOrder
    {
        private Stock _stock;

        public SellStock(Stock stock)
        {
            _stock = stock;
        }

        public void Execute()
        {
            _stock.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _order = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _order.Add(order);
        }

        public void PlaceOrder()
        {
            foreach (var order in _order)
            {
                order.Execute();
            }

            _order.Clear();
        }
    }
}
