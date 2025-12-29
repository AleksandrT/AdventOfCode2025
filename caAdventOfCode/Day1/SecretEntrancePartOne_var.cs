using System;
using System.Collections.Generic;
using System.IO;

namespace caAdventOfCode.Day1
{
    public class SecretEntrancePartOne_var
    {
        private const int DialSize = 100;
        public int Password { get; private set; }
        public int FinalDial { get; private set; }
        public int StartDial { get; }

        public SecretEntrancePartOne_var(int startDial = 50)
        {
            StartDial = NormalizeDial(startDial);
            FinalDial = StartDial;
            Password = 0;
        }

        public void ProcessMoves(IEnumerable<string> moves)
        {
            if (moves == null) throw new ArgumentNullException(nameof(moves));

            foreach (var raw in moves)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;

                var entry = raw.Trim();
                if (!TryParseMove(entry, out var direction, out var steps))
                {
                    // ignore invalid lines
                    continue;
                }

                if (direction == 'L')
                {
                    FinalDial -= steps;
                }
                else // assume 'R' for any other valid direction
                {
                    FinalDial += steps;
                }

                FinalDial = NormalizeDial(FinalDial);

                if (FinalDial == 0)
                {
                    Password++;
                }
            }
        }

        public static int CalculatePassword(IEnumerable<string> moves, int startDial = 50)
        {
            var solver = new SecretEntrancePartOne_var(startDial);
            solver.ProcessMoves(moves);
            return solver.Password;
        }

        public static IEnumerable<string> LoadLinesFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path)) throw new FileNotFoundException("Input file not found", path);
            return File.ReadAllLines(path);
        }

        private static bool TryParseMove(string input, out char direction, out int steps)
        {
            direction = default;
            steps = 0;

            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return false;
            }

            direction = input[0];
            return int.TryParse(input.Substring(1), out steps) && (direction == 'L' || direction == 'R');
        }

        private static int NormalizeDial(int dial)
        {
            // ensure dial is within [0, DialSize-1]
            var mod = dial % DialSize;
            return mod < 0 ? mod + DialSize : mod;
        }

        public static IEnumerable<string> GetTestData()
        {
            return new []
            {
                "L68",
                "L30",
                "R48",
                "L5",
                "R60",
                "L55",
                "L1",
                "L99",
                "R14",
                "L82",
                "R764"
            };
        }
    }
}
