using System.Numerics;

namespace caAdventOfCode.Day2
{
    public class GiftShop
    {
        private int _invalidIDs;
        private bool useTestData = false;
        private List<string> _inputs = new List<string>();
        public GiftShop()
        {
            LoadData();
            CalculateInvalidIDs();
            Console.WriteLine($"There are : {_invalidIDs} of invalid IDs");
        }

        private void LoadData()
        {
            var _data = System.String.Empty;

            if (useTestData)
            {
                _data = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
            }
            else
            {
                try
                {
                    var _dataSource = @"..\\..\\..\\Data\\InputsDay2.txt";
                    if (!File.Exists(_dataSource))
                    {
                        Console.WriteLine("File not found!");
                        return;
                    }
                    foreach (var line in File.ReadAllLines(_dataSource))
                    {
                            _data = (!string.IsNullOrWhiteSpace(line)) ? line.Trim() : String.Empty;                       
                    }
                }
                catch
                {
                    Console.WriteLine("File found, but wasn't able to read it!");
                }
            }
            _inputs = _data.Split(',').Select(s => s.Trim()).ToList();
        }

        private void CalculateInvalidIDs()
        {            
            foreach (var _input in _inputs)
            {
                string[] _parts = _input.Split('-');
                BigInteger _partOne = BigInteger.Parse(_parts[0]);
                BigInteger _partTwo = BigInteger.Parse(_parts[1]);

                for (var n = _partOne; n <= _partTwo; n++)
                {
                    string val = n.ToString();
                    int half = val.Length / 2;
                    
                    _invalidIDs += (val.Substring(0, half).Equals(val.Substring(half))) ? 1 : 0;                    
                }
            }
        }
    }
}
