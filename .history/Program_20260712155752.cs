using System;
using System.Linq;

// 1. User se naam lena (Yeh sirf aik dafa shuru me pugainge)
Console.Clear();
Console.WriteLine("================================================");
Console.WriteLine("   WELCOME TO SUNDRI ENTERPRISE CALCULATOR V3   ");
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

    // Poori expression aik sath lena
    Console.WriteLine("\nEnter your addition expression (e.g., 10+20+5+3):");
    Console.Write("Expression: ");
    string? expression = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(expression))
    {
        Console.WriteLine("\n[ERROR] Expression cannot be empty!");
    }
    else
    {
        // KAINCHI CHALANA: '+' ke sign se saare tukde alag kar do
        string[] numbersText = expression.Split('+');

        int totalSum = 0;
        bool hasInvalidInput = false;

        // FOREACH LOOP: Har ek tukde ko baari-baari check karna aur jama karna
        foreach (string token in numbersText)
        {
            // Spaces khatam karne ke liye Trim
            string cleanToken = token.Trim();

            // Check karo k kya yeh tukda asli number hai?
            if (int.TryParse(cleanToken, out int actualNumber))
            {
                totalSum += actualNumber;
            }
            else
            {
                Console.WriteLine($"\n[ERROR] '{cleanToken}' is not a valid number!");
                hasInvalidInput = true;
                break; // Loop ko yahin rok do, aage calculation ka faida nahi
            }
        }

        // Agar saare inputs valid the, to final result dikhao
        if (!hasInvalidInput)
        {
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine($"Execution Result: Total Sum = {totalSum}");
            Console.WriteLine("------------------------------------------------");
        }
        else
        {
            Console.WriteLine("\n[ERROR] Execution Failed due to invalid inputs inside the expression.");
        }
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