using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace lab_2
{
    internal class fileGetter
    {
        public void FileGenerator()
        {
            string PathName = "/Users/downstize/Downloads/lab_2/someFiles";
            Random random = new Random();

            for (int i = 1; i <= 2300; i++)
            {
                string filePath = Path.Combine(PathName, $"file{i}.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int j = 0; j < 5000; j++)
                    {
                        int randomNumber = random.Next(-10, 11);
                        writer.WriteLine(randomNumber);
                    }
                }
            }
            Console.WriteLine("Процесс создания 2300 файлов завершен!");
        }
        public  void ClearFolder()
        {
            string PathName = "/Users/downstize/Downloads/lab_2/someFiles";
            DirectoryInfo directory = new DirectoryInfo(PathName);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }

    }
}
