using System;

// 1. User se naam lena
Console.WriteLine("Calculator ka istemal karne ke liye, aapko apna naam enter karna hoga.");
string? userName = Console.ReadLine();

// 2. First digit lena
Console.WriteLine($"{userName} ap koi bhi 2 digits dein humm add kr k dien gy ... First digit dy:");
string? input1 = Console.ReadLine();

// 3. Second digit lena
Console.WriteLine("Second digit dy:");
string? input2 = Console.ReadLine();

// 4. Variables pehle hi declare kar diye jahan number save honge
int num1;
int num2;

// 5. The Pro-Engineer Check (TryParse ka istemal)
bool isFirstValid = int.TryParse(input1, out num1);
bool isSecondValid = int.TryParse(input2, out num2);

// 6. Condition laga kar check karna k dono inputs valid numbers hain ya nahi
if (isFirstValid && isSecondValid)
{
    // Agar dono sahi numbers hain, toh plus karo aur output dikhao
    int result = num1 + num2;
    Console.WriteLine($"Aapne diye hue digits ka total sum hai: {result}");
}
else
{
    // Agar kisi aik me bhi text hua, toh crash nahi hoga, balkay yeh message aayega
    Console.WriteLine("Error: Bhai jaan, aap ne inputs me number ki jagah alphabet/text enter kiya hai. Sahi digits enter karein!");
}