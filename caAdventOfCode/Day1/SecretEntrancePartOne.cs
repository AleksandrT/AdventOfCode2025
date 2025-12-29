using System;
using System.Collections.Generic;
using System.IO;

namespace caAdventOfCode.Day1
{
    public class SecretEntrancePartOne
    {
        private int _password;
        private int _dial = 50;
        private readonly List<string> _inputs = new List<string>();
        //public int Password => _password;
        private bool useTestData = false;
        public SecretEntrancePartOne()
        {
            LoadData();
            CalculatePassword();
            Console.WriteLine($"Password is {_password}");
        }

        private void LoadData()
        {
            if (useTestData)
            {
                var data = @"L68
                            L30
                            R48
                            L5
                            R60
                            L55
                            L1
                            L99
                            R14
                            L82
                            R764";

                using (var reader = new StringReader(data))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            _inputs.Add(line.Trim());
                        }
                    }
                }
                return;
            }

            try
            {
                var localPath = @"C:\Users\40124401\source\repos\AleksandrT\AdvemtOfCode2025\caAdventOfCode\Data\InputsDay1Part1.txt";
                if (File.Exists(localPath))
                {
                    foreach (var line in File.ReadAllLines(localPath))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            _inputs.Add(line.Trim());
                        }
                    }

                    return;
                }
                Console.WriteLine("File not found!");
            }
            catch
            {
                Console.WriteLine("File found, but wasn't able to read it!");
            }
        }

        private void CalculatePassword()
        {
            foreach (var input in _inputs)
            {
                if (string.IsNullOrEmpty(input)) continue;

                var direction = input[0];
                if (!int.TryParse(input.Substring(1), out var steps)) continue;

                if (direction == 'L')
                {
                    _dial -= steps;
                }
                else if (direction == 'R')
                {
                    _dial += steps;
                }

                if (_dial < 0)
                {
                    _dial += 10000;
                }

                _dial %= 100;

                if (_dial == 0)
                {
                    _password += 1;
                }
            }
        }
    }
}
