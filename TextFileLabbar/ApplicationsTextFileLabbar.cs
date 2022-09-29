using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace TextFileLabbar
{
    public class ApplicationsTextFileLabbar
    {
        public List<Car> GetFromFile()
        {
            var listOfCars = new List<Car>();
            if (!File.Exists("Cars.txt"))
            {
                return listOfCars;
            }

            var text = File.ReadAllText("Cars.txt");
            listOfCars = JsonConvert.DeserializeObject<List<Car>>(text);

            return listOfCars;
        }
        public void SaveCar(List<Car> listOfCars)
        {
            var text = JsonConvert.SerializeObject(listOfCars);

            using (var file = File.CreateText("Cars.txt"))
            {
                file.Write(text);
            }
        }
        public string RemoveCar()
        {


            int b = 0;


            return b.ToString();
        }
        public Car CreateCar()
        {
            Console.Write("Ange Namn: ");
            string Name = Console.ReadLine();

            Console.Write("Ange Model: ");
            string Model = Console.ReadLine();

            Console.Write("Ange År: ");
            int Year = int.Parse(Console.ReadLine());

            Console.Write("Ange Pris: ");
            int Price = int.Parse(Console.ReadLine());

            var car = new Car();
            car.Name = Name;
            car.Model = Model;
            car.Year = Year;
            car.Price = Price;

            return car;
        }
        public int GetIntInput(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                try
                {
                    int sel = Convert.ToInt32(Console.ReadLine());
                    if (sel < minValue || sel > maxValue)
                        Console.WriteLine($"Mata in ett tal mellan {minValue} och {maxValue} tack");

                    else
                        return sel;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Mata in siffror tack");
                }
            }
        }
        public void Lab7()
        {
            bool run = true;
            while (run)
            {
                var menyVal = GetIntInput("Ange menyval\n1. Skapa Bil\n2. Ta Bort Bil\n3. Exit And Save", 1, 3);

                switch (menyVal)
                {
                    case 1:
                        
                        CreateCar();

                        break;

                    case 2:

                        break;

                    case 3:

                        var listOfCars = GetFromFile();

                        SaveCar(listOfCars);

                        run = false;


                        break;
                }
            }




        }
















        public void Lab6()
        {

            Console.Write("Ange path ->");
            var path = Console.ReadLine();
            Console.Write("Ange del av filnamn att söka efter ->");
            var fileNamePart = Console.ReadLine();

            foreach (var filePath in Directory.GetFiles(path))
            {
                var fileName = Path.GetFileName(filePath);
                if (fileName.ToLower().Contains(fileNamePart.ToLower()))
                {
                    var size = new FileInfo(filePath).Length;
                    Console.WriteLine($"{fileName} - bytes = {size}");
                }
            }
        }


        public bool VerifyUserNameAndPassword(string username, string password)
        {
            if (!File.Exists("username.txt"))
            {
                return false;
            }
            foreach (var row in File.ReadLines("username.txt"))
            {
                var splitter = row.IndexOf('_');
                if (splitter != -1)
                {
                    var un = row.Substring(0, splitter);
                    var pwd = row.Substring(splitter + 1);
                    if (un == username && pwd == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UserNameExists(string username)
        {
            if (!File.Exists("username.txt"))
            {
                return false;
            }

            foreach (var row in File.ReadLines("username.txt"))
            {
                var splitter = row.IndexOf('_');
                if (splitter != -1)
                {
                    var un = row.Substring(0, splitter);
                    if (un == username)
                        return true;
                }
            }
            return false;
        }

        public void Register()
        {

            while (true)
            {
                Console.WriteLine("*** NEW REGISTRATION ***");

                Console.WriteLine("Ange ett username");
                var username = Console.ReadLine();

                if (username.Length == 0)
                {
                    Console.WriteLine("Ange ett username tack");
                    continue;
                }

                if (UserNameExists(username))
                {
                    Console.WriteLine("Username already exists");
                    continue;
                }

                Console.WriteLine("Ange ett password");

                var password = Console.ReadLine();
                if (password.Length == 0)
                {
                    Console.WriteLine("Ange ett password tack");
                    continue;
                }
                File.AppendAllLines("username.txt", new List<string> { username + "_" + password });

                break;
            }
        }
        public void Login()
        {
            Console.WriteLine("*** LOGIN ***");
            Console.WriteLine("Ange ditt username");
            var username = Console.ReadLine().Trim();

            Console.WriteLine("Ange ditt password");
            var password = Console.ReadLine().Trim();

            if (VerifyUserNameAndPassword(username, password))
            {
                Console.WriteLine("Du är inloggad");
            }
            else
                Console.WriteLine("Fel username eller password");
        }

        public void Lab5()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("Ange menyval");
                Console.WriteLine("a = login\nb = register\nq = quit");
                var menyVal = Console.ReadLine();


                switch (menyVal)
                {
                    case "a":

                        Login();
                        break;

                    case "b":

                        Register();
                        break;

                    case "q":

                        run = false;
                        break;

                }
            }

        }

        public void Lab4()
        {

            var list = File.ReadAllLines("C:\\Users\\chris\\OneDrive\\Bilder\\Downloaded\\Lab4TextFile-InData1.txt").ToList();
            list.Sort();

            using (var file = File.CreateText("SortedBirds.txt"))
            {
                foreach (var bird in list)
                {
                    file.WriteLine(bird);
                }
            }
        }

        public void Lab3()
        {
            using (var file = File.CreateText("NewFileWithNumbers.txt"))
            {
                int i = 1;

                foreach (var row in File.ReadLines("Lab3File1.txt"))
                {
                    file.WriteLine($"{i}. {row}");
                    i++;
                }
            }
        }
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

                odd = !odd;
            }
        }

        public void Run()
        {
            //Lab1();
            //Lab2();
            //Lab3();
            //Lab4();
            //Lab5();
            //Lab6();
            Lab7();

        }
    }
}
