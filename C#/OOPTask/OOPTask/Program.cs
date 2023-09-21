using System;
using System.Runtime.InteropServices;


public struct dimensiune
{
    decimal lungime;
    decimal latime;
    decimal inaltime;
};
public abstract class Animal
{
    public Animal(string c_name,decimal c_greutate,dimensiune c_dimesiune, decimal c_viteza)
    {
        c_name = name;
        c_greutate = greutate;
        c_viteza = viteza;
        c_dimesiune = dim;

    }
    public string name { get; set; }
    public decimal greutate { get; set; }
    public dimensiune dim;
    public decimal viteza { get; set; }
    protected List<Mancare> stomac = new List<Mancare>();

    public void Mananca(Mancare m)
    {
        if (greutate / 8 <= 1)
        {
            Console.WriteLine("mananca");
            stomac.Add(m);
        }    
    }
    public abstract double Energie();
    public void Alearga (decimal distanta)
    {
        double timp = Convert.ToDouble(distanta) / (Convert.ToDouble(viteza) / Energie());
        Console.WriteLine("timp = " + timp);
    }
}

public class Carnivor : Animal
{
    public Carnivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
    {
    }

    public override double Energie()
    {
        decimal sumaEnergieMancare = stomac.Sum(Mancare => Mancare.greutate); // Nu sunt sigur ca trebue sa lucreze in felul dat
        decimal mediaGreutateMancare = sumaEnergieMancare / stomac.Count;
        return 0.5 + (1.0 / 3.0) * (double)(mediaGreutateMancare + sumaEnergieMancare);
    }
}
public class Erbivor : Animal
{
    public Erbivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
    {
    }

    public override double Energie()
    {
        throw new NotImplementedException();
    }
}
public class Omnivor : Animal
{
    public Omnivor(string c_name, decimal c_greutate, dimensiune c_dimesiune, decimal c_viteza) : base(c_name, c_greutate, c_dimesiune, c_viteza)
    {
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


