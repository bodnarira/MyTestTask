using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyTestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Put a correct file path
            string filePath = "D:/MyDocuments/MyTestTask/test.txt";

            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadLines(filePath).ToList();
                int countOfCorrectPasswords = 0;
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string clearLine = line.Trim();
                    char letter = clearLine[0];
                    string[] parts = clearLine.Split(' ');

                    if (parts.Length < 3) continue;

                    string rule = parts[1].Replace(":", string.Empty);
                    var password = parts[2].ToList();
                    int count = password.Count(p => p == letter);

                    var limits = rule.Split("-");
                    try
                    {
                        if (limits.Length == 1 && count == int.Parse(limits[0]))
                        {
                            countOfCorrectPasswords++;
                        }
                        if (limits.Length == 2 && count >= int.Parse(limits[0]) && count <= int.Parse(limits[1]))
                        {
                            countOfCorrectPasswords++;
                        }
                    
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Incorrect restriction: {rule} for a password in line: {line}");
                        continue;
                    }
                    
                }
                Console.WriteLine("Count of correct passwords: " + countOfCorrectPasswords);
            }

            
            Console.ReadKey();
        }
    }
}
