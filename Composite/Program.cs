using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee can = new Employee{name = "Can"};
            Employee enes = new Employee{name = "Enes"};
            can.AddSubordinate(enes);
            Employee gizem = new Employee {name = "Gizem"};
            can.AddSubordinate(gizem);
            Employee irem = new Employee {name = "İrem"};
            gizem.AddSubordinate(irem);

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string name { get; set; }
    }

    class Employee : IPerson , IEnumerable<IPerson>
    {
        List<IPerson> _subordinate = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinate.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinate.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinate[index];
        }

        public string name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinate)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
