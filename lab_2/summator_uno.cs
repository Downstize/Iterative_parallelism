using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;

namespace lab_2
{
    internal class SummatorUno
    {
        private static readonly string PathName = "/Users/downstize/Downloads/lab_2/someFiles";
        private static int resultSum = 0;
        
        public int Summator()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            for (int i = 1; i <= 2300; i++)
            {
                ProccessFile(i);
            }
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine("Время выполнения: " + elapsed);
            Console.WriteLine($"Полная сумма в файлах: {resultSum}");
            return resultSum;
        }

        private static void ProccessFile(int fileNum)
        {
            string filePath = Path.Combine(PathName, $"file{fileNum}.txt");

            using (StreamReader reader = new StreamReader(filePath))
            {
                int fileSum = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        fileSum += number;
                    }
                }

                resultSum += fileSum;
            }
        }
    }
    
}
