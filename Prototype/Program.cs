using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirstName = "Can",
                LastName = "Özaytekin",
                City = "İstanbul",
                Id = 1
            };
            Console.WriteLine(customer.FirstName);

            Customer customer2 = (Customer)customer.Clone();
            customer2.FirstName = "Enes";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
