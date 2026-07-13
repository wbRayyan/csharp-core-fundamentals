using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

// 1. User authentication and session setup
Console.Clear();
Console.WriteLine("================================================");
Console.WriteLine("   WELCOME TO SUNDRI ENTERPRISE CALCULATOR V7   ");
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

    Console.WriteLine("\nEnter expression (e.g., -.5*.5/.5-.5+.5+.5):");
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
            cleanExpression = cleanExpression.Substring(1);
        }
        else if (cleanExpression.StartsWith("+"))
        {
            cleanExpression = cleanExpression.Substring(1);
        }

        // 2. Tokenize numbers using all math operators as split delimiters
        char[] delimiters = { '+', '-', '*', '/' };
        string[] numbersText = cleanExpression.Split(delimiters);

        // 3. Extract all mathematical operators sequentially
        char[] operatorsArray = cleanExpression.Where(c => c == '+' || c == '-' || c == '*' || c == '/').ToArray();

        // 4. Transform raw arrays into flexible dynamic lists
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

        if (isValid && numbersList.Count > 0)
        {
            // Apply negative mapping to the first token if a leading minus was stripped
            if (isFirstNumberNegative)
            {
                numbersList[0] = -numbersList[0];
            }

            // ===================================================
            // BODMAS STAGE 1: Handle Multiplication and Division
            // ===================================================
            int index = 0;
            while (index < operatorsList.Count)
            {
                char op = operatorsList[index];

                if (op == '*' || op == '/')
                {
                    double num1 = numbersList[index];
                    double num2 = numbersList[index + 1];
                    double intermediateResult = 0;

                    if (op == '*')
                    {
                        intermediateResult = num1 * num2;
                    }
                    else if (op == '/')
                    {
                        if (num2 == 0)
                        {
                            Console.WriteLine("\n[MATH ERROR] Division by zero is undefined.");
                            isValid = false;
                            break;
                        }
                        intermediateResult = num1 / num2;
                    }

                    // Update the numbers list with evaluated result and compress structures
                    numbersList[index] = intermediateResult;
                    numbersList.RemoveAt(index + 1);
                    operatorsList.RemoveAt(index);
                    
                    // Keep index same because elements shifted left
                }
                else
                {
                    index++;
                }
            }

            // ===================================================
            // BODMAS STAGE 2: Handle Addition and Subtraction
            // ===================================================
            if (isValid)
            {
                double totalSum = numbersList[0];
                for (int i = 0; i < operatorsList.Count; i++)
                {
                    char op = operatorsList[i];
                    double nextNumber = numbersList[i + 1];

                    if (op == '+')
                    {
                        totalSum += nextNumber;
                    }
                    else if (op == '-')
                    {
                        totalSum -= nextNumber;
                    }
                }

                // Output formatting block based on evaluation status
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine($"Execution Result: Total = {totalSum}");
                Console.WriteLine("------------------------------------------------");
            }
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