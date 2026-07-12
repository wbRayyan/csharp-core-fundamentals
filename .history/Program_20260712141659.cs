using System;
using System.Linq; // Yeh zaroori hai taake hum .Any() use kar sakein

// 1. User se naam lena
Console.WriteLine("To use Sundri Calculator, please enter your name:");
string? userName = Console.ReadLine();

// NAAM KA CHECK: Agar naam khali hai, ya usme koi bhi character Digit (number) hai
if (string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit))
{
    Console.WriteLine("Name can't be empty or contain numbers. Please restart the program and enter a valid name.");
    return; // Program ko yahin rok do, agay math par mat jao
}

// 2. First digit lena
Console.WriteLine($"{userName} Input the first digit:");
string? input1 = Console.ReadLine();

// 3. Second digit lena
Console.WriteLine($"{userName} Input the second digit:");
string? input2 = Console.ReadLine();


// 4. Variables declaration
int num1;
int num2;

// 5. TryParse Check
bool isFirstValid = int.TryParse(input1, out num1);
bool isSecondValid = int.TryParse(input2, out num2);

// 6. Final Calculation Condition
if (isFirstValid && isSecondValid)
{
    Console.WriteLine($"You entered: {num1} and {num2}");
}
else
{
    Console.WriteLine("Error: Inputs me sirf digits (numbers) enter karein!");
}

Console.WriteLine($"{userName} Select the operation you want to perform: +, -, *, /");
string? operation = Console.ReadLine();

Console.WriteLine($"{userName} You selected: {operation}");
Console.WriteLine($"{userName} Performing the operation...");
Console.WriteLine($"{userName} The result is: {num1} {operation} {num2}");