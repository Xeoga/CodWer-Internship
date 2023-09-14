//Sarcina 1
//a) citește de la tastatura un număr cu minim de 3 cifre dacă
//numărul are mai puțin de 3 cifre, îi spune utilizatorului
//acest lucru și îi cere alt număr
//b) dacă numărul este corect, calculeaza valoarea in
//oglinda (ex 441 in oglinda este 144)
//c) verifica și îi spune userului dacă numărul dat în oglinda
//este pătrat perfect (ex 144 = 12 * 12 - ok)

using System;
using System.ComponentModel.Design;

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
double minNumber = (double)numere[0];
foreach (var numar in numere)
{
    if (minNumber > numar)
    {
        minNumber = numar;
    }
}
Console.WriteLine("Min number is: " + minNumber);
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
