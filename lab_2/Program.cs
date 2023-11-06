using System;
using System.IO;

namespace lab_2
{
    public class program
    {
     public static async Task Main(string[] args)
        {
            fileGetter fileGetter = new fileGetter();
            SummatorUno summatorUno = new SummatorUno();
            SummatorMulti summatorMulti = new SummatorMulti();
             fileGetter.ClearFolder();
             fileGetter.FileGenerator();
            Console.WriteLine("Однопоточное решение:  " + summatorUno.Summator());
            Console.WriteLine("Многопоточное решение  "+ summatorMulti.Summator());
        }  
    }
     
}