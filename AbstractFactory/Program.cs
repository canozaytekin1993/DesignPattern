using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager _productManager = new ProductManager(new Factory1());
            _productManager.GetAll();
            Console.ReadLine();
        }

        public abstract class Logging
        {
            public abstract void Log(string message);
        }

        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with Log4Net");
            }
        }

        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with nLogger");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }

        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }

        public class RadisCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RadisCache");
            }
        }

        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }

            public override Caching CreateCaching()
            {
                return new RadisCache();
            }
        }

        public class Factory2 : CrossCuttingConcernsFactory
        {
            public override Logging CreateLogger()
            {
                return new NLogger();
            }

            public override Caching CreateCaching()
            {
                return new MemCache();
            }
        }

        public class ProductManager
        {
            private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;

            private Logging _logging;
            private Caching _caching;

            public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _logging = crossCuttingConcernsFactory.CreateLogger();
                _caching = crossCuttingConcernsFactory.CreateCaching();
            }

            public void GetAll()
            {
                _logging.Log("Logged");
                _caching.Cache("Data");
                Console.WriteLine("Products listed!");
            }
        }
    }
}
