using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customer = new CustomerManager();
            customer.MessageManagerBase = new MailSender();
            customer.UpdateCustomer();
            Console.ReadLine();
        }
    }

    abstract class MessageManagerBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageManagerBase
    {
        #region Overrides of MessageManagerBase

        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body.Title);
        }

        #endregion
    }

    class SmsSender : MessageManagerBase
    {
        #region Overrides of MessageManagerBase

        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }

        #endregion
    }

    class CustomerManager
    {
        public MessageManagerBase MessageManagerBase { get; set; }
        public void UpdateCustomer()
        {
            MessageManagerBase.Send(new Body { Title = "About the course!" });
            Console.WriteLine("Customer updated");
        }
    }
}
