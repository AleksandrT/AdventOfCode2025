using static System.Console;

WriteLine("Welcome Advent of Code 2025!");

ConsoleKeyInfo userChoice;

do { 

    WriteLine("");
    WriteLine("Please select the day to run or select 'q' to exit.");
    WriteLine("Enter 1 to run Day 1: Secret Entrance");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    WriteLine("");
    userChoice = ReadKey();

    switch (userChoice.KeyChar)
    {
        case '1':
            WriteLine("Day 1: Secret Entrance");
            new caAdventOfCode.Day1.SecretEntrancePartOne();
            break;
        default:
            break;
    }

} while (userChoice.KeyChar.ToString().ToLower() != "q");

Console.Clear();