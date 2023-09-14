// See https://aka.ms/new-console-template for more information
using System;
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

//Console.WriteLine("Your number is "number);