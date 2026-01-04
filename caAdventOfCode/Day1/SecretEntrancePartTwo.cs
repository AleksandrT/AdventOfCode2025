namespace caAdventOfCode.Day1
{
    public class SecretEntrancePartTwo
    {
        private int _password;
        private int _dial = 50;
        private readonly List<string> _inputs = new List<string>();
        private bool useTestData = false;
        public SecretEntrancePartTwo()
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
                            L82";

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
                var localPath = @"..\..\..\Data\InputsDay1.txt";
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
            foreach (var _input in _inputs)
            {
                if (string.IsNullOrEmpty(_input)) continue;

                var _direction = _input[0];
                if (!int.TryParse(_input.Substring(1), out var _steps)) continue;

                while (_steps > 0) 
                { 
                    if (_direction == 'L')
                    {
                        _dial--;
                    }
                    else if (_direction == 'R')
                    {
                        _dial++;
                    }
                    if (Math.Abs(_dial) == 100)
                    {
                        _dial = 0;
                    }
                    
                    if (_dial == 0)
                    {                        
                        _password += 1;
                    }                                       
                    _steps--;
                }
            }
        }
    }
}
