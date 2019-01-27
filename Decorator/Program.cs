﻿using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);

            Console.WriteLine("Concrete : {0}", personelCar.HirePrice);
            Console.WriteLine("Concrete : {0}", specialOffer.HirePrice);

            Console.ReadLine();

        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            this.carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        #region Overrides of CarBase

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get { return _carBase.HirePrice; }
            set { }
        }

        #endregion
    }
}
