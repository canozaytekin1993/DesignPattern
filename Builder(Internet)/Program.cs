using System;

namespace Builder_Internet_
{
    // Product class
    public class Pizza
    {
        public string PizzaTipi { get; set; }
        public string Hamur { get; set; }
        public string Sos { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", PizzaTipi, Hamur, Sos);
        }
    }

    // Builder class
    public abstract class PizzaBuilder
    {
        protected Pizza _pizza;

        public Pizza Pizza
        {
            get { return _pizza; }
        }

        public abstract void SosHazirla();
        public abstract void HamuruHazirla();
    }

    // ConcreteBuilder class
    public class BaharatliPizzaBuilder : PizzaBuilder
    {
        public BaharatliPizzaBuilder()
        {
            _pizza = new Pizza {PizzaTipi = "Baharatlı Baharatlı"};
        }

        public override void SosHazirla()
        {
            _pizza.Sos = "Acı sos,pepperoni,atom biber";
        }

        public override void HamuruHazirla()
        {
            _pizza.Hamur = "İnce Kenar, Kaşarlı";
        }

    }

    // ConcreteBuilder Class
    public class DortMevsimPizzaBuilder : PizzaBuilder
    {
        public DortMevsimPizzaBuilder()
        {
            _pizza = new Pizza {PizzaTipi = "4 Mevsim"};
        }

        public override void SosHazirla()
        {
            _pizza.Sos = "Biber,Domates,Peynir,Salam,Sosis";
        }

        public override void HamuruHazirla()
        {
            _pizza.Hamur = "Kalın,fesleğenli";
        }
    }

    // Director class
    public class VenedikliKamil
    {
        public void Olustur(PizzaBuilder vBuilder)
        {
            vBuilder.SosHazirla();
            vBuilder.HamuruHazirla();
        }
    }

    // Client Class
    class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder vBuilder;

            VenedikliKamil kamil = new VenedikliKamil();
            vBuilder = new BaharatliPizzaBuilder();

            kamil.Olustur(vBuilder);
            Console.WriteLine(vBuilder.Pizza.ToString());

            vBuilder = new DortMevsimPizzaBuilder();
            kamil.Olustur(vBuilder);
            Console.WriteLine(vBuilder.Pizza.ToString());
        }
    }
}
