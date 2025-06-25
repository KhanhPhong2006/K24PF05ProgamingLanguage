using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

class SinhVien
{
    public string HoTen { get; set; }
    public string MSSV { get; set; }
    public double Diem { get; set; }
    public string Lop { get; set; }
}

class Program
{
    static FirebaseClient firebase = new FirebaseClient("https://lab06-f6bad-default-rtdb.firebaseio.com/");

    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Nhập sinh viên và ghi vào Firebase");
            Console.WriteLine("2. Hiển thị toàn bộ sinh viên");
            Console.WriteLine("3. Cập nhật sinh viên");
            Console.WriteLine("4. Xoá sinh viên");
            Console.WriteLine("5. Lấy Top 5 sinh viên theo điểm");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var sv = NhapSinhVien();
                    await GhiSinhVien(sv);
                    break;
                case "2":
                    await HienThiSinhVien();
                    break;
                case "3":
                    await CapNhatSinhVien();
                    break;
                case "4":
                    await XoaSinhVien();
                    break;
                case "5":
                    await LayTop5SinhVien();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static SinhVien NhapSinhVien()
    {
        Console.Write("Nhập MSSV: ");
        string mssv = Console.ReadLine();
        Console.Write("Họ tên: ");
        string hoTen = Console.ReadLine();
        Console.Write("Điểm: ");
        double diem = double.Parse(Console.ReadLine());
        Console.Write("Lớp: ");
        string lop = Console.ReadLine();

        return new SinhVien
        {
            MSSV = mssv,
            HoTen = hoTen,
            Diem = diem,
            Lop = lop
        };
    }

    static async Task GhiSinhVien(SinhVien sv)
    {
        try
        {
            await firebase.Child("sinhvien").Child(sv.MSSV).PutAsync(sv);
            Console.WriteLine(" Đã ghi dữ liệu lên Firebase.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Lỗi khi ghi dữ liệu: " + ex.Message);
        }
    }

    static async Task HienThiSinhVien()
    {
        try
        {
            var sinhViens = await firebase.Child("sinhvien").OnceAsync<SinhVien>();
            Console.WriteLine("\n--- Danh sách sinh viên ---");
            foreach (var item in sinhViens)
            {
                var sv = item.Object;
                Console.WriteLine($"MSSV: {sv.MSSV}, Họ tên: {sv.HoTen}, Điểm: {sv.Diem}, Lớp: {sv.Lop}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Lỗi khi đọc dữ liệu: " + ex.Message);
        }
    }

    static async Task CapNhatSinhVien()
    {
        Console.Write("Nhập MSSV cần cập nhật: ");
        string mssv = Console.ReadLine();
        var svMoi = NhapSinhVien();
        svMoi.MSSV = mssv;

        try
        {
            await firebase.Child("sinhvien").Child(mssv).PutAsync(svMoi);
            Console.WriteLine(" Cập nhật thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Lỗi cập nhật: " + ex.Message);
        }
    }

    static async Task XoaSinhVien()
    {
        Console.Write("Nhập MSSV cần xoá: ");
        string mssv = Console.ReadLine();

        try
        {
            await firebase.Child("sinhvien").Child(mssv).DeleteAsync();
            Console.WriteLine(" Đã xoá sinh viên.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Lỗi xoá: " + ex.Message);
        }
    }
    static async Task LayTop5SinhVien()
{
    try
    {
        var sinhViens = await firebase.Child("sinhvien").OnceAsync<SinhVien>();

        
        var top5 = sinhViens
            .Select(x => x.Object)
            .OrderByDescending(sv => sv.Diem)
            .Take(5)
            .ToList();

        
        await firebase.Child("TopStudent").PutAsync(top5);

        Console.WriteLine("\n Đã ghi danh sách Top 5 sinh viên vào Firebase (TopStudent).");
        foreach (var sv in top5)
        {
            Console.WriteLine($"{sv.MSSV} - {sv.HoTen} - {sv.Diem} - {sv.Lop}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(" Lỗi khi xử lý Top 5: " + ex.Message);
    }
}

}

