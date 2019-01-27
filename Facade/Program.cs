using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Save();
            Console.ReadLine();
        }
    }

    class Logging : Ilogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface Ilogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class Customer
    {
        #region Kötü Kullanım Örneği
        //private Ilogging _logging;
        //private ICaching _caching;
        //private IAuthorize _authorize;

        //public Customer(Ilogging logging,ICaching caching,IAuthorize authorize)
        //{
        //    _caching = caching;
        //    _logging = logging;
        //    _authorize = authorize;
        //}

        //public void Save()
        //{
        //    _logging.Log();
        //    _caching.Cache();
        //    _authorize.CheckUser();
        //    Console.WriteLine("Saved");
        //}
        #endregion

        private CrossCuttingConcernFacade _concern;
        public Customer()
        {
            _concern = new CrossCuttingConcernFacade();
        }

        public void Save()
        {
            _concern.Caching.Cache();
            _concern.Authorize.CheckUser();
            _concern.Logging.Log();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernFacade
    {
        public Ilogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
