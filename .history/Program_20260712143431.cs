using System;
using System.Linq;

// 1. User se naam lena
Console.WriteLine("To use Sundri Calculator, please enter your name:");
string? userName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit))
{
    Console.WriteLine("Name can't be empty or contain numbers. Please restart the program and enter a valid name.");
    return;
}

// 2. First digit lena
Console.WriteLine($"{userName} Input the first digit:");
string? input1 = Console.ReadLine();

// 3. Second digit lena
Console.WriteLine($"{userName} Input the second digit:");
string? input2 = Console.ReadLine();

int num1;
int num2;

bool isFirstValid = int.TryParse(input1, out num1);
bool isSecondValid = int.TryParse(input2, out num2);

// Yahan se logic change hogi
if (isFirstValid && isSecondValid)
{
    Console.WriteLine($"You entered: {num1} and {num2}");
    
    // Operation validation ke andar hi maangein ge taake galat input par code agay na bhage
    Console.WriteLine($"{userName} Select the operation you want to perform: +, -, *, /");
    string? operation = Console.ReadLine();

    Console.WriteLine($"{userName} You selected: {operation}");
    Console.WriteLine($"{userName} Performing the operation...");

    int result = 0;
    bool validOperation = true;

    // SWITCH CASE: Yeh check karega k user ne kaunsa sign dabaya hai aur wahi math karega
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
            // Division by zero check (Safety)
            if (num2 == 0)
            {
                Console.WriteLine("Error: Mathematical rule ke mutabiq aap 0 se divide nahi kar sakte!");
                validOperation = false;
            }
            else
            {
                result = num1 / num2;
            }
            break;
        default:
            Console.WriteLine("Error: Invalid operation selected!");
            validOperation = false;
            break;
    }

    // Agar operation sahi tha toh final result dikhao
    if (validOperation)
    {
        Console.WriteLine($"{userName} The result is: {result}");
    }
}
else
{
    Console.WriteLine("Error: Inputs me sirf digits (numbers) enter karein!");
}