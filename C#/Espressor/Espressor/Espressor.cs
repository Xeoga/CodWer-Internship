using System;
namespace Espressor
{
    public class Expressor
    {

        protected Boiler boil = new Boiler();
        public void Menu()
        {
            Console.WriteLine("===========Espressor===========");
            Console.WriteLine("1. Start");
            Console.WriteLine("2. Verificarea apei");
            Console.WriteLine("3. Pune suportul pentru apa");
            Console.WriteLine("0. Exit.=(");
            int nrMenu = Convert.ToInt32(Console.ReadLine());

            if (nrMenu >= 0 && nrMenu <= 10)
            {
                switch (nrMenu)
                {
                    case 1:
                        Console.WriteLine("Este elictricitate.");
                        break;
                    case 2:
                        if (boil.checkLevelWather())
                        {
                            Console.WriteLine($"Nivelul apei este {boil.watherLevel}");
                        }
                        else
                        {
                            Console.WriteLine($"Nivelul apei nu este suficient {boil.watherLevel}");

                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opss optiune incorecta. :(");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Expressor masina = new Expressor();
            masina.Menu();
        }
    }
}