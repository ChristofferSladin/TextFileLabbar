using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileLabbar
{
    internal class ApplicationsTextFileLabbar
    {

        public void Lab2()
        {
            using (var file = File.CreateText("ResultLab2.txt"))


            {
                foreach (var row in File.ReadLines("Lab2TextFile1.txt"))
                {
                    
                    file.WriteLine(row);
                }
                    

                foreach (var row in File.ReadLines("Lab2TextFile2.txt"))
                {
                    
                    file.WriteLine(row);
                }
            }
        }

        public void Lab1()
        {
            var odd = true;

            foreach (var row in File.ReadLines("Labb1.txt"))
            {
                if (odd)
                Console.WriteLine(row);
            }
        }

        public void Run()
        {
            //Lab1();
            Lab2();

        }
    }
}
