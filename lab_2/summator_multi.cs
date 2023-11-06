using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;


namespace lab_2
{
    internal class SummatorMulti
    {

        private static readonly string PathName = "/Users/downstize/Downloads/lab_2/someFiles";
        private static int resultSum = 0;

        public int Summator()
        {
            Thread[] threads = new Thread[2300];
            DateTime startTime = DateTime.Now;
            for (int i = 1; i <= 2300; i++)
            {
                int fileNumber = i;
                threads[i - 1] = new Thread(() => ProcessFile(ref fileNumber));
                threads[i - 1].Start();
            }
            Parallel.ForEach(threads, thread => { thread?.Join(); });
            DateTime endTime = DateTime.Now;
            TimeSpan elapsedTime = endTime - startTime;
            Console.WriteLine($"Время выполнения: {elapsedTime}");
            Console.WriteLine($"Полная сумма в файлах: {resultSum}");
            return resultSum;
        }

        private static void ProcessFile(ref int fileNumber)
        {
            string filePath = $"{PathName}/file{fileNumber}.txt";
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
                Interlocked.Add(ref resultSum, fileSum);
            }
        }
    }

}
