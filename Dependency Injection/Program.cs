using System;

namespace Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ninject Yüklendikten sonra eklenmesi gereken kodlar.
            // IKernel kernel = new StandardKernel();
            // kernel.Bind<IProductDal>().To<EfProductDal>();

            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Save();
            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }
    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }

    class ProductManager
    {
        IProductDal _productDal = new EfProductDal();

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
