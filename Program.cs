using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

// 1. User authentication and session setup
Console.Clear();
Console.WriteLine("================================================");
Console.WriteLine("   WELCOME TO SUNDRI ENTERPRISE CALCULATOR V6   ");
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

    Console.WriteLine("\nEnter expression (e.g., -9.5-9 or 10.2+20.5-5):");
    Console.Write("Expression: ");
    string? expression = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(expression))
    {
        Console.WriteLine("\n[ERROR] Expression cannot be empty!");
    }
    else
    {
        // Sanitize input by removing all whitespaces
        string cleanExpression = expression.Replace(" ", "");

        // Edge Case Handling: Check if expression starts with a leading sign (+ or -)
        bool isFirstNumberNegative = false;
        if (cleanExpression.StartsWith("-"))
        {
            isFirstNumberNegative = true;
            cleanExpression = cleanExpression.Substring(1); // Remove leading sign for smooth splitting
        }
        else if (cleanExpression.StartsWith("+"))
        {
            cleanExpression = cleanExpression.Substring(1); // Strip explicit leading plus sign
        }

        // 2. Tokenize numbers using operators as split delimiters
        char[] delimiters = { '+', '-' };
        string[] numbersText = cleanExpression.Split(delimiters);

        // 3. Extract remaining operators sequentially
        char[] operatorsArray = cleanExpression.Where(c => c == '+' || c == '-').ToArray();

        // 4. Data Structure Transformation: Move raw arrays into Dynamic Lists
        List<double> numbersList = new List<double>();
        List<char> operatorsList = new List<char>(operatorsArray);
        
        bool isValid = true;

        // Parse and populate the numbers list sequentially
        foreach (string token in numbersText)
        {
            if (double.TryParse(token, CultureInfo.InvariantCulture, out double parsedNum))
            {
                numbersList.Add(parsedNum);
            }
            else
            {
                isValid = false;
                break;
            }
        }

        double totalSum = 0;

        // 5. Execution Block using Dynamic Data Structures
        if (isValid && numbersList.Count > 0)
        {
            // Apply negative sign mapping to the first number if a leading minus was stripped
            totalSum = isFirstNumberNegative ? -numbersList[0] : numbersList[0];

            // Compute remaining sequential operations
            for (int i = 0; i < operatorsList.Count; i++)
            {
                char op = operatorsList[i];
                double nextNumber = numbersList[i + 1]; // Safely extract the adjacent token

                if (op == '+')
                {
                    totalSum += nextNumber;
                }
                else if (op == '-')
                {
                    totalSum -= nextNumber;
                }
            }
        }
        else
        {
            isValid = false;
        }

        // Output formatting block based on evaluation status
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