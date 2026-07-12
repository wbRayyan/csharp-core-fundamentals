using System;

Console.WriteLine("Welcome to the Journey!");
Console.WriteLine("Apna naam enter karein:");
Console.WriteLine("Calculator ka istemal karne ke liye, aapko apna naam enter karna hoga.");
string userName = Console.ReadLine();
Console.WriteLine($"Ap koi bhi 2 digits dy jo humm add kr k dien gy, {userName}!");
string input1 = Console.ReadLine();
Console.WriteLine("Dusra digit dy:");
string input2 = Console.ReadLine();
Console.WriteLine($"Apke diye hue digits: {input1} + {input2}");





using System;

Console.WriteLine("Calculator ka istemal karne ke liye, aapko apna naam enter karna hoga.");
// Warning hatane ke liye hum string ke sath '?' lagate hain (yaani it can be null)
string? userName = Console.ReadLine();

Console.WriteLine($"{userName} ap koi bhi 2 digits dein humm add kr k dien gy ... First digit dy:");
string? input1 = Console.ReadLine();

Console.WriteLine("Second digit dy:");
string? input2 = Console.ReadLine();

// YAHA REAL MATH HO RAHA HAI: Text ko Number me convert kar rahe hain
int num1 = int.Parse(input1 ?? "0"); // Agar khali ho toh 0 maan lo
int num2 = int.Parse(input2 ?? "0");

// Dono numbers ko plus kar ke aik teesre variable me save kiya
int result = num1 + num2;

// Final Output
Console.WriteLine($"Aapne diye hue digits ka total sum hai: {result}");
