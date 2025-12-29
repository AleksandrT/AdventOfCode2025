using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace caAdventOfCode.Day1
{
    public class SecretEntrancePartOne
    {
        int password = 0;
        int dial = 50;
        private List<string> inputs = new List<string>();
        public SecretEntrancePartOne()
        {
            //GetInputs();
            GetData();
            SolvePassword();
            Console.WriteLine($"Password is {password}");
        }

        private void SolvePassword()
        {
            foreach (var input in inputs)
            {
                char direction = input[0];
                int steps = int.Parse(input.Substring(1));

                if (direction == 'L')
                {               
                    dial -= steps;                    
                }
                else if (direction == 'R')
                {
                    dial += steps;
                }

                if (dial < 0)
                {
                    dial += 10000;
                }
                dial = dial % 100;

                if (dial == 0)
                {
                    password += 1;
                }                
            }
        }

        private void GetInputs()
        {
            using (StringReader reader = new StringReader(GetTestData()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    inputs.Add(line.Trim());
                }
            }
        }

        private string GetTestData()
        {
            return @"L68
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
        }

        private void GetData()
        {
            try
            {
                var localPath = @"C:\Users\40124401\source\repos\AleksandrT\AdvemtOfCode2025\caAdventOfCode\Data\InputsDay1Part1.txt";
                if (File.Exists(localPath))
                {
                    foreach (var line in File.ReadAllLines(localPath))
                    {
                        if (!string.IsNullOrWhiteSpace(line)) inputs.Add(line.Trim());
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("File not found!");
                }
            }
            catch
            {
                Console.WriteLine("File found, but wanst able to read it!");
            }

            // Attempt to download from Advent of Code using optional session cookie in env var AOC_SESSION
            //try
            //{
            //    var url = "https://adventofcode.com/2025/day/1/input";

            //    using (var client = new HttpClient())
            //    {
            //        var session = Environment.GetEnvironmentVariable("AOC_SESSION");

            //        if (!string.IsNullOrEmpty(session))
            //        {
            //            client.DefaultRequestHeaders.Add("Cookie", $"session={session}");
            //        }

            //        var content = client.GetStringAsync(url).GetAwaiter().GetResult();

            //        using (var reader = new StringReader(content))
            //        {
            //            string line;
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                if (!string.IsNullOrWhiteSpace(line)) inputs.Add(line.Trim());
            //            }
            //        }
            //        return;
            //    }
            //}
            //catch
            //{
            //    // ignore network errors and fall back to test data
            //}

            // Fallback to embedded test data
            //using (StringReader reader = new StringReader(GetTestData()))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        if (!string.IsNullOrWhiteSpace(line)) inputs.Add(line.Trim());
            //    }
            //}
        } 
    }
}
