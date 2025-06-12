using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Nhap x: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Nhap y: ");
                int y = int.Parse(Console.ReadLine());

                double Mauso = 2 * x - y;
                if (Mauso == 0)
                    throw new DivideByZeroException("Mau so khong the bang 0!");

                double Tuso = 3 * x + 2 * y;
                double Ketqua = Tuso / Mauso;

                if (Ketqua < 0)
                    throw new NotNegativeException("Bieu thuc duoi can khong the nho hon 0!");

                double H = Math.Sqrt(Ketqua);
                Console.WriteLine($"Gia tri cua H: {H}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Loi: Dinh dang đau vao khong hop le!");
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
            Console.ReadLine();
        }
    }

    class NotNegativeException : Exception
    {
        public NotNegativeException(string message) : base(message) { }
    }
}
    

