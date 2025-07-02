using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

public class Player
{
    public string Name { get; set; }
    public int VipLevel { get; set; }
    public string Region { get; set; }
    public DateTime LastLogin { get; set; }
}

class Program
{
    static FirebaseClient firebase = new FirebaseClient("https://lab11-34a73-default-rtdb.firebaseio.com/");

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
        HttpClient http = new HttpClient();
        string json = await http.GetStringAsync(url);
        var players = JsonConvert.DeserializeObject<List<Player>>(json);

        DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
        int totalVip = players.Count(p => p.VipLevel > 0);
        Console.WriteLine($"Tổng số người chơi VIP: {totalVip}");

        var vipByRegion = players
            .Where(p => p.VipLevel > 0)
            .GroupBy(p => p.Region)
            .Select(g => new { Region = g.Key, Count = g.Count() });

        Console.WriteLine("\nSố lượng người chơi VIP theo khu vực:");
        foreach (var item in vipByRegion)
        {
            Console.WriteLine($"Khu vực: {item.Region} - Số lượng VIP: {item.Count}");
        }

        var allVipPlayers = players
            .Where(p => p.VipLevel > 0)
            .ToList();

        Console.WriteLine("\nTất cả người chơi VIP:");
        foreach (var p in allVipPlayers)
        {
            Console.WriteLine($"Tên: {p.Name} - VIP: {p.VipLevel} - Khu vực: {p.Region} - Đăng nhập: {p.LastLogin}");
        }

        var firebaseNode = firebase.Child("quiz_bai2_allVipPlayers");
        await firebaseNode.DeleteAsync(); 

        foreach (var p in allVipPlayers)
        {
           
            string key = p.Name.Replace(" ", "_");
            await firebaseNode.Child(key).PutAsync(p);
        }

        Console.WriteLine("\n Đã đẩy toàn bộ người chơi VIP lên Firebase bằng key cố định.");
    }
}

