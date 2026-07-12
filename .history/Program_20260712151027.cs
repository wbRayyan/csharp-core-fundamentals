using System;
using System.Linq;

// 1. User se naam lena (Yeh sirf aik dafa shuru me pugainge)
Console.Clear();
Console.WriteLine("================================================");
Console.WriteLine("   WELCOME TO SUNDRI ENTERPRISE CALCULATOR V2   ");
Console.WriteLine("================================================");
Console.WriteLine("\nPlease enter your name to access the core engine:");
string? userName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit))
{
    Console.WriteLine("\n[ERROR] Name cannot be empty, contain spaces only, or digits.");
    Console.WriteLine("Execution terminated. Press any key to exit...");
    Console.ReadKey();
    return;
}

// Global variable taake loop ke andar data save rahe
bool keepRunning = true;

// MAIN LOOP: Yeh tab tak chalta rahega jab tak keepRunning false na ho
while (keepRunning)
{
    Console.Clear(); // Har dafa screen saaf
    Console.WriteLine("================================================");
    Console.WriteLine($" Session Active: {userName.ToUpper()}");
    Console.WriteLine("================================================");

    // First digit lena
    Console.Write("\nInput the first digit: ");
    string? input1 = Console.ReadLine();

    // Second digit lena
    Console.Write("Input the second digit: ");
    string? input2 = Console.ReadLine();

    int num1;
    int num2;

    bool isFirstValid = int.TryParse(input1, out num1);
    bool isSecondValid = int.TryParse(input2, out num2);

    if (isFirstValid && isSecondValid)
    {
        Console.WriteLine("\nSelect operation: [ + ] [ - ] [ * ] [ / ]");
        Console.Write("Your choice: ");
        string? operation = Console.ReadLine();

        int result = 0;
        bool shouldPrintResult = true;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("\n[MATH ERROR] Division by zero is undefined.");
                    shouldPrintResult = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("\n[ERROR] Invalid operation sequence selected.");
                shouldPrintResult = false;
                break;
        }

        if (shouldPrintResult)
        {
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine($"Execution Result: {num1} {operation} {num2} = {result}");
            Console.WriteLine("------------------------------------------------");
        }
    }
    else
    {
        Console.WriteLine("\n[ERROR] Core parsing failed. Inputs must be numerical integers.");
    }

    // USER RE-ENTRY CHECK: Yeh program ko chalata rakhega
    Console.WriteLine("\nDo you want to perform another calculation? (y/n): ");
    string? choice = Console.ReadLine()?.ToLower();

    if (choice != "y" && choice != "yes")
    {
        keepRunning = false; // Loop break ho jayega
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine($" Thank you for using Sundri Calculator, {userName}! ");
        Console.WriteLine("================================================");
    }
}