/*Sarcina 1
a) citește de la tastatura un număr cu minim de 3 cifre dacă
numărul are mai puțin de 3 cifre, îi spune utilizatorului
acest lucru și îi cere alt număr
b) dacă numărul este corect, calculeaza valoarea in
oglinda (ex 441 in oglinda este 144)
c) verifica și îi spune userului dacă numărul dat în oglinda
este pătrat perfect (ex 144 = 12 * 12 - ok)
*/
/*Sarcina 2
 * a) citește de la tastatura o lista de numere (pot fi si numere
reale) despărțite prin spațiu și le salvează într-un array
b) parcurge array-ul și le afișează pe cele care nu sunt
întregi
c) cauta si afiseaza cel mai mic numar fara sa folosesti
funcții din .NET (Math.Min)
 */
/*Sarcina 3
 * a) citește de la tastatura 3 nume de persoane (ex. George
Ion Maria)
b) afișează pe cate o linie ce caracter a apărut în fiecare
nume și de cate ori indiferent ca-i cu litera mica sau
mare
 */
using System;
using System.ComponentModel.Design;


void Task2()
{
    Console.WriteLine("Enter number: ");
    string input = Console.ReadLine();
    string[] cuvinte = input.Split(' ');
    double[] numere = new double[cuvinte.Length];
    for (int i = 0; i < cuvinte.Length; i++)
    {
        numere[i] = Convert.ToDouble(cuvinte[i]);
    }
    Console.WriteLine("The numbers are: ");
    foreach (var numar in numere)
    {
        Console.WriteLine(numar);
    }

    void IntegerOrNot()
    {
        foreach (var numar in numere)
        {
            if (numar % 1 == 0)
            {
                Console.WriteLine("Integer: " + numar);
            }
            else
            {
                Console.WriteLine("Not integer: " + numar);
            }
        }
    }
    double searchMinNumber()
    {
        double minNumber = (double)numere[0];
        foreach (var numar in numere)
        {
            if (minNumber > numar)
            {
                minNumber = numar;
            }
        }
        Console.WriteLine("Min number is: " + minNumber);
        return minNumber;
    }
}
void Task1()
{
    Console.WriteLine("Enter number:");
    int number = int.Parse(Console.ReadLine());
    string numStr = number.ToString();

    while (numStr.Length < 3)
    {
        Console.WriteLine("You number is wrong:");
        Console.WriteLine("Enter number:");
        number = int.Parse(Console.ReadLine());
        numStr = number.ToString();
    }

    int oglindaNumber = ReverseNumber(numStr);
    Console.WriteLine("The number is: " + numStr);
    Console.WriteLine("Reversed number is : " + oglindaNumber);

    double result = Math.Sqrt(oglindaNumber);
    if (result % 1 == 0)
    {
        Console.WriteLine("Is perfect square:");
    }
    else
    {
        Console.WriteLine("Is not perfect square:");
    }

    int ReverseNumber(string numStr)
    {
        char[] charArray = numStr.ToCharArray();
        Array.Reverse(charArray);
        string reversedStr = new string(charArray);
        int reversedNum = int.Parse(reversedStr);
        return reversedNum;
    }
}
