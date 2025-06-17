using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatHang
{
    public int MaMH { get; set; }
    public string TenMH { get; set; }
    public int SoLuong { get; set; }
    public double DonGia { get; set; }


    public MatHang(int ma, string ten, int sl, double gia)
    {
        MaMH = ma;
        TenMH = ten;
        SoLuong = sl;
        DonGia = gia;
    }


    public double ThanhTien()
    {
        return SoLuong * DonGia;
    }


    public void Xuat()
    {
        Console.WriteLine($"{MaMH,-10} {TenMH,-20} {SoLuong,-10} {DonGia,-15:C} {ThanhTien(),-15:C}");
    }
}

class Program
{

    static void ThemMatHang(List<MatHang> ds)
    {
        Console.Write("Nhap ma mat hang: ");
        int ma = int.Parse(Console.ReadLine());

        Console.Write("Nhap ten mat hang: ");
        string ten = Console.ReadLine();

        Console.Write("Nhap so luong: ");
        int sl = int.Parse(Console.ReadLine());

        Console.Write("Nhap don gia: ");
        double gia = double.Parse(Console.ReadLine());

        ds.Add(new MatHang(ma, ten, sl, gia));
    }


    static bool TimMatHang(List<MatHang> ds, int ma, out MatHang found)
    {
        foreach (var mh in ds)
        {
            if (mh.MaMH == ma)
            {
                found = mh;
                return true;
            }
        }
        found = null;
        return false;
    }


    static void XuatDanhSach(List<MatHang> ds)
    {
        Console.WriteLine("\n{0,-10} {1,-20} {2,-10} {3,-15} {4,-15}", "MaMH", "TenMH", "SoLuong", "DonGia", "ThanhTien");
        Console.WriteLine(new string('-', 70));
        foreach (var mh in ds)
        {
            mh.Xuat();
        }
    }


    static void XoaMatHang(List<MatHang> ds, int ma)
    {
        MatHang found;
        if (TimMatHang(ds, ma, out found))
        {
            ds.Remove(found);
            Console.WriteLine("Da xoa mat hang co ma {0}.", ma);
        }
        else
        {
            Console.WriteLine("Khong tim thay mat hang co ma {0}.", ma);
        }
    }


    static void Main()
    {
        List<MatHang> danhSach = new List<MatHang>();
        string tiepTuc;


        do
        {
            Console.WriteLine("\n=== Nhap mat hang moi ===");
            ThemMatHang(danhSach);
            Console.Write("Ban co muon nhap tiep? (c/k): ");
            tiepTuc = Console.ReadLine().ToLower();
        } while (tiepTuc == "c");


        Console.WriteLine("\n=== Danh sach cac mat hang ===");
        XuatDanhSach(danhSach);


        Console.Write("\nNhap ma mat hang can tim va xoa: ");
        int maCanXoa = int.Parse(Console.ReadLine());
        XoaMatHang(danhSach, maCanXoa);
        Console.WriteLine("\n=== Danh sach sau khi xoa (neu co) ===");
        XuatDanhSach(danhSach);
    }
}
