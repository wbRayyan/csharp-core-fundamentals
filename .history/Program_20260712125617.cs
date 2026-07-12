using System;

Console.WriteLine("Calculator ka istemal karne ke liye, aapko apna naam enter karna hoga.");
string? userName = Console.ReadLine();

Console.WriteLine($"{userName} ap koi bhi 2 digits dein humm add kr k dien gy ... First digit dy:");
string? input1 = Console.ReadLine();

Console.WriteLine("Second digit dy:");
string? input2 = Console.ReadLine();

int num1 = int.Parse(input1 ?? "0"); 
int num2 = int.Parse(input2 ?? "0");

int result = num1 + num2;

Console.WriteLine($"Aapne diye hue digits ka total sum hai: {result}");
