using System;
using System.Runtime.InteropServices;

namespace T1
{

    public struct dimensiune
    {
        public decimal lungime { get; set; }
        public decimal latime { get; set; }
        public decimal inaltime { get; set; }
        public dimensiune (decimal _lungime, decimal _latime, decimal _inaltime)
        {
            lungime = _lungime;
            latime = _latime;
            inaltime = _inaltime;
        }
    };
    public abstract class Animal
    {
        public Animal(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza)
        {
            name = c_name;
            greutate = c_greutate;
            viteza = c_viteza;
            dim = c_dimesiune;
            count++;

        }
        static int count;
        public static string name { get; set; }
        protected decimal greutate { get; set; }
        protected dimensiune dim;
        protected decimal viteza { get; set; }
        protected List<Mancare> stomac = new List<Mancare>();
        public override string ToString()
        {
            return $"==================================\n"+
                   $"Tip animal: {this.GetType().Name}\n" +
                   $"Nume: {name}\n" +
                   $"Greutate: {greutate} kg\n" +
                   $"Dimensiuni: {dim.lungime} x {dim.latime} x {dim.inaltime}\n" +
                   $"Viteza: {viteza} kg\n";
        }
        public abstract void Mananca(Mancare m);
       
        public abstract double Energie();
        public void Alearga(decimal distanta)
        {
            decimal timp = distanta / (viteza / Convert.ToDecimal(Energie()));
            Console.WriteLine($"timpul = {timp} secunde");
        }
        public int numar()
        {
            return count;
        }
    }
    public class Carnivor : Animal
    {
        public Carnivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
        {
        }
        public override void Mananca(Mancare m)
        {
            if (m is Carne)
                if (m.greutate <= this.greutate / 8)
                {
                    stomac.Add(m);
                    Console.WriteLine("Mananca");
                }
        }
        public override double Energie()
        {
            decimal mediaGreutateMan = stomac.Sum(man => man.greutate) / stomac.Count();
            decimal sumEnerg = stomac.Sum(man => man.energie);
            return 0.2 - 1 / 5 * Convert.ToDouble(mediaGreutateMan) + Convert.ToDouble(sumEnerg);
        }
    }
    public class Erbivor : Animal
    {
        public Erbivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
        {
        }
        public override void Mananca(Mancare m)
        {
            if (m is Planta)
                if (m.greutate <= this.greutate / 8)
                {
                    stomac.Add(m);
                    Console.WriteLine("Mananca");
                }
        }

        public override double Energie()
        {
            decimal mediaGreutateMan = stomac.Sum(man => man.greutate) / stomac.Count();
            decimal sumEnerg = stomac.Sum(man => man.energie);
            return 0.5 - 1 / 3 * Convert.ToDouble(mediaGreutateMan) + Convert.ToDouble(sumEnerg);
        }
    }
    public class Omnivor : Animal
    {
        public Omnivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
        {
        }
        public override void Mananca(Mancare m)
        {
            if (m.greutate <= this.greutate / 8)
            {
                stomac.Add(m);
                Console.WriteLine("Mananca");
            }
        }
        public override double Energie()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Mancare
    {
        public decimal greutate { get; set; }
        public decimal energie { get; set; }
    }
    public class Carne : Mancare
    {

    }
    public class Planta : Mancare
    {

    }
    public class Program
    {
        enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca };
        static Animal CreeazaAnimal(TipAnimal animal_tip, string _name, decimal _greutatea, dimensiune _dim, decimal _viteza)
        {
            if (animal_tip == TipAnimal.Lup || animal_tip == TipAnimal.Pisica)
            {
                return new Carnivor(_name, _greutatea, _dim, _viteza);
            }
            else if (animal_tip == TipAnimal.Oaie || animal_tip == TipAnimal.Vaca)
            {
                return new Erbivor(_name, _greutatea, _dim, _viteza);
            }
            else
            {
                return new Omnivor(_name, _greutatea, _dim, _viteza);
            }
        }
        public static void Main(string[] args)
        {
            Animal lup = (Animal)CreeazaAnimal(TipAnimal.Lup, "Fedea", 70, new dimensiune(30, 40, 50), 10);

            dimensiune dLup = new dimensiune(20, 10, 40);
            Carnivor Lup = new Carnivor("Jora", 150, dLup, 12);
            dimensiune dOaie = new dimensiune(10, 5, 20);
            Erbivor Oaie = new Erbivor("Prietenul_lui_Jora", 100, dOaie, 12);
            dimensiune dUrs = new dimensiune(100, 100, 100);
            Omnivor Urs = new Omnivor("Pasoc", 200, dUrs, 120);
            Planta salata = new Planta();
            Carne sunca = new Carne();

            Lup.Mananca(sunca);
            Lup.Mananca(sunca);

            Oaie.Mananca(salata);
            Oaie.Mananca(salata);
            Oaie.Mananca(salata);

            Urs.Mananca(sunca);
            Urs.Mananca(salata);

            // Este impartirea la 0 returneaza eroare:
            //Lup.Alearga(200);
            //Oaie.Alearga(200);
            //Urs.Alearga(200);

            Console.WriteLine(Urs);

            List<Animal> listaGoala = new List<Animal>();

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                int numarAliator = random.Next(0, 3);
                if (numarAliator == 0)
                {
                    Array animal = Enum.GetValues(typeof(TipAnimal));
                    int indexAleatoriu = random.Next(animal.Length);
                    TipAnimal animalAliator = (TipAnimal)animal.GetValue(indexAleatoriu);
                    string name = animalAliator.ToString();
                    decimal deciAliator = random.Next(0, 55);
                    listaGoala.Add(CreeazaAnimal(animalAliator, name, deciAliator, new dimensiune(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20)), random.Next(0, 100)));
                }
                else if (numarAliator == 1)
                {
                    Array animal = Enum.GetValues(typeof(TipAnimal));
                    int indexAleatoriu = random.Next(animal.Length);
                    TipAnimal animalAliator = (TipAnimal)animal.GetValue(indexAleatoriu);
                    string name = animalAliator.ToString();
                    decimal deciAliator = random.Next(0, 55);
                    listaGoala.Add(CreeazaAnimal(animalAliator, name, deciAliator, new dimensiune(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20)), random.Next(0, 100)));
                }
                else
                {
                    Array animal = Enum.GetValues(typeof(TipAnimal));
                    int indexAleatoriu = random.Next(animal.Length);
                    TipAnimal animalAliator = (TipAnimal)animal.GetValue(indexAleatoriu);
                    string name = animalAliator.ToString();
                    decimal deciAliator = random.Next(0, 55);
                    listaGoala.Add(CreeazaAnimal(animalAliator, name, deciAliator, new dimensiune(random.Next(0, 20), random.Next(0, 20), random.Next(0, 20)), random.Next(0, 100)));
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(listaGoala[i]);
                if (listaGoala[i] is Carnivor)
                {
                    Carne Sunca = new Carne();
                    listaGoala[i].Mananca(Sunca);
                }
                else if (listaGoala[i] is Erbivor)
                {
                    Planta Earba = new Planta();
                    listaGoala[i].Mananca(Earba);
                }
                else
                {
                    Carne Sunca = new Carne();
                    listaGoala[i].Mananca(Sunca);
                }
            }


            int animaleMancare = listaGoala.Count(animal => animal is Animal);
            int animaleCarne = listaGoala.Count(animal => animal is Carnivor);
            int animalePlante = listaGoala.Count(animal => animal is Erbivor);

            Console.WriteLine($"{animaleMancare} animale mănâncă mâncare.");
            Console.WriteLine($"{animaleCarne} animale mănâncă carne.");
            Console.WriteLine($"{animalePlante} animale mănâncă plante.");
        }
    }
}