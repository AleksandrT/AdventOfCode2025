using static System.Console;

WriteLine("Welcome Advent of Code 2025!");

ConsoleKeyInfo userChoice;

do { 
    WriteLine("");
    WriteLine("Please select the day to run or select 'q' to exit.");
    WriteLine("---------------------------------------------------");
    WriteLine("Enter 1 to run Day 1: Secret Entrance Part one.");
    WriteLine("Enter 2 to run Day 1: Secret Entrance Part two.");
    WriteLine("Enter 3 to run Day 2: Gift shop.");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    userChoice = ReadKey();

    switch (userChoice.KeyChar)
    {
        case '1':
            WriteLine("\nDay 1: Secret Entrance - part one");
            new caAdventOfCode.Day1.SecretEntrancePartOne();
            break;
        case '2':
            WriteLine("\nDay 1: Secret Entrance - part two");
            new caAdventOfCode.Day1.SecretEntrancePartTwo();
            break;
        case '3':
            WriteLine("\nDay 2: Gift shope - part one");
            new caAdventOfCode.Day2.GiftShop();
            break;

        default:
            break;
    }

} while (userChoice.KeyChar.ToString().ToLower() != "q");

Console.Clear();