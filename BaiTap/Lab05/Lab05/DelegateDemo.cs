using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class DelegateDemo
    {
        public delegate void Logger();
        public delegate void Display();
        public static void Main(string[] args)
        {
           
            DisplayHandler objEvents = new DisplayHandler(); 
            objEvents.Print += () => Console.WriteLine("Display event triggered");
            objEvents.Show(); 

            Temperature tempConversion = new Temperature(FahreheiToCelsius);
            double tempF = 96;
            double tempC = tempConversion(tempF);

            Console.WriteLine("Temperature in Fahrenheit: " + tempF);
            Console.WriteLine("Temperature in Celsius: " + tempC);
            Console.WriteLine("DELEGATE");

            ChaoBanDelegate btn01 = delegate (string name)
            {
                Console.WriteLine("BTN01");
            };
            ChaoBanDelegate btn02 = delegate (string name)
            {
                Console.WriteLine(" BTN02");
            };
            ChaoBanDelegate btn03 = delegate (string name)
            {
                Console.WriteLine("BTN03");
            };
            ChaoBanDelegate btn04 = (string s) => Console.WriteLine("LAMDA: " + s);
            btn01?.Invoke("Nguyen Van A");
            btn02?.Invoke("Nguyen Van B");
            btn03?.Invoke("Nguyen Van C");
            Logger logger = LogToFile;
            logger += LogToConsole;
            logger?.Invoke();
            TinhToan2thamso add = new TinhToan2thamso(FabricPlus);
            float result = (float)add((float)5.5, (float)4.5);
        }

        public delegate double Temperature(double tempF);
        public static double FahreheiToCelsius(double tempF)
        {
            return (tempF - 32) * 5 / 9;
        }
        delegate void MyDelegate();
        delegate void MyDelegateVD02(string s);
        delegate float TinhToan2thamso(float a, float b);

        public static float FabricPlus(float a, float b)
        {
            return a + b;
        }
        delegate void ChaoBanDelegate(string name);
        public static void ChaoBan(string name)
        {
            Console.WriteLine("Xin Chao: " + name);
        }
        public static void LogToFile() => Console.WriteLine("Ghi vao File");
        public static void LogToConsole() => Console.WriteLine("Hien thi Console");
    }

    internal class DisplayHandler
    {
        public event DelegateDemo.Display Print;
        public void Show()
        {
            Console.WriteLine("Show method called");
            Print?.Invoke();
        }
    }
}
