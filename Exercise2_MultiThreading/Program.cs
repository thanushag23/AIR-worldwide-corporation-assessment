using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise2_MultiThreading
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: <inputFile> <outputFile>");
                return 1;
            }

            var inputPath = args[0];
            var outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Input file not found: {inputPath}");
                return 1;
            }

            var lines = await File.ReadAllLinesAsync(inputPath);

            var results = new string[lines.Length];

            Parallel.For(0, lines.Length, i =>
            {
                var text = lines[i].Trim();
                if (int.TryParse(text, out int n))
                {
                    results[i] = (n * n).ToString();
                }
                else
                {
                    Console.Error.WriteLine($"Skipping invalid integer on line {i + 1}: '{text}'");
                    results[i] = null; // we'll filter this out later
                }
            });

            var outLines = results.Where(r => !string.IsNullOrEmpty(r));
            await File.WriteAllLinesAsync(outputPath, outLines);

            Console.WriteLine($"Processed {outLines.Count()} numbers → {outputPath}");
            return 0;
        }
    }
}
