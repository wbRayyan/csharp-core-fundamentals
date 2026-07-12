using System;
using System.Linq; // Yeh zaroori hai taake hum .Any() use kar sakein

// 1. User se naam lena
Console.WriteLine("Calculator ka istemal karne ke liye, aapko apna naam enter karna hoga.");
string? userName = Console.ReadLine();

// NAAM KA CHECK: Agar naam khali hai, ya usme koi bhi character Digit (number) hai
if (string.IsNullOrWhiteSpace(userName) || userName.Any(char.IsDigit))
{
    Console.WriteLine("Naam me numbers, digits ya blank spaces nahi ati, aur na hi naam khali ho sakta hai!");
    return; // Program ko yahin rok do, agay math par mat jao
}

// 2. First digit lena
Console.WriteLine($"{userName} ap koi bhi 2 digits dein humm add kr k dien gy ... First digit dy:");
string? input1 = Console.ReadLine();

// 3. Second digit lena
Console.WriteLine("Second digit dy:");
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
    int result = num1 + num2;
    Console.WriteLine($"Aapne diye hue digits ka total sum hai: {result}");
}
else
{
    Console.WriteLine("Error: Inputs me sirf digits (numbers) enter karein!");
}