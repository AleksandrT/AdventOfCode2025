namespace caAdventOfCode.Day2
{
    public class GiftShop
    {
        private int _invalidIDs;
        private bool useTestData = false;
        public GiftShop()
        {
            LoadData();
            CalculateInvalidIDs();
            Console.WriteLine($"There are : {_invalidIDs} of invalid IDs");
        }

        private void LoadData()
        {
            if (useTestData)
            {
                var data = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
                            1698522-1698528,446443-446449,38593856-38593862,565653-565659,
                            824824821-824824827,2121212118-2121212124";

                using (var reader = new StringReader(data))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            //_inputs.Add(line.Trim());
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
                            //_inputs.Add(line.Trim());
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

        private void CalculateInvalidIDs()
        {
            //foreach (var input in //_inputs)
            //{
            //    if (string.IsNullOrEmpty(input)) continue;

            //    var direction = input[0];
            //    if (!int.TryParse(input.Substring(1), out var steps)) continue;

            //    if (direction == 'L')
            //    {
            //        _dial -= steps;
            //    }
            //    else if (direction == 'R')
            //    {
            //        _dial += steps;
            //    }

            //    if (_dial < 0)
            //    {
            //        _dial += 10000;
            //    }

            //    _dial %= 100;

            //    if (_dial == 0)
            //    {
            //        _password += 1;
            //    }
            }
        
    }
}
