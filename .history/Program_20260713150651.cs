using System;
using System.Linq;

// 1. User se naam lena (Once)
Console.Clear();
Console.WriteLine("================================================");
Console.WriteLine("   WELCOME TO SUNDRI ENTERPRISE CALCULATOR V4   ");
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

bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("================================================");
    Console.WriteLine($" Session Active: {userName.ToUpper()}");
    Console.WriteLine("================================================");

    Console.WriteLine("\nEnter expression with + and - (e.g., 10+20-5+3):");
    Console.Write("Expression: ");
    string? expression = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(expression))
    {
        Console.WriteLine("\n[ERROR] Expression cannot be empty!");
    }
    else
    {
        // Spaces saaf karna
        string cleanExpression = expression.Replace(" ", "");

        // 1. Pehle hum saare numbers alag kar lete hain
        char[] delimiters = { '+', '-' };
        string[] numbersText = cleanExpression.Split(delimiters);

        // 2. Ab hum saare signs (operators) alag dhoondte hain
        // Yeh line expression mein se sirf '+' aur '-' nikal legi
        char[] operators = cleanExpression.Where(c => c == '+' || c == '-').ToArray();

        int totalSum = 0;
        bool isValid = true;

        // Pehle number ko validation ke sath totalSum me bitha do
        if (numbersText.Length > 0 && int.TryParse(numbersText[0], out int firstNumber))
        {
            totalSum = firstNumber;
        }
        else
        {
            isValid = false;
        }

        // 3. LOOP: Ab baqi ke saare numbers par unke signs ke mutabiq operation chalana
        for (int i = 0; i < operators.Length; i++)
        {
            char op = operators[i]; // Agla sign kaunsa hai?
            
            // Us sign ke agay wala number uthao (isliye i + 1 use kiya)
            if (int.TryParse(numbersText[i + 1], out int nextNumber))
            {
                if (op == '+')
                {
                    totalSum += nextNumber;
                }
                else if (op == '-')
                {
                    totalSum -= nextNumber;
                }
            }
            else
            {
                isValid = false;
                Console.WriteLine($"\n[ERROR] Invalid number detected after '{op}'");
                break;
            }
        }

        if (isValid)
        {
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine($"Execution Result: Total = {totalSum}");
            Console.WriteLine("------------------------------------------------");
        }
        else
        {
            Console.WriteLine("\n[ERROR] Parsing failed. Please check your expression syntax.");
        }
    }

    Console.WriteLine("\nDo you want to perform another calculation? (y/n): ");
    string? choice = Console.ReadLine()?.ToLower();

    if (choice != "y" && choice != "yes")
    {
        keepRunning = false;
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine($" Thank you for using Sundri Calculator, {userName}! ");
        Console.WriteLine("================================================");
    }
}