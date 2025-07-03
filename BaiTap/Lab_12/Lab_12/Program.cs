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
    public bool IsActive { get; set; }
    public DateTime LastLogin { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
}

class Program
{
    static readonly string jsonUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
    static readonly string firebaseUrl = "https://lab12-79466-default-rtdb.asia-southeast1.firebasedatabase.app/";

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var httpClient = new HttpClient();
        string jsonData = await httpClient.GetStringAsync(jsonUrl);
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonData);

        var now = new DateTime(2025, 06, 30, 0, 0, 0, DateTimeKind.Utc);

        
        var inactivePlayers = players
            .Where(p => !p.IsActive || (now - p.LastLogin).TotalDays > 5)
            .Select(p => new
            {
                p.Name,
                p.IsActive,
                p.LastLogin
            }).ToList();

        Console.WriteLine("== Danh sách người chơi không hoạt động ==");
        foreach (var p in inactivePlayers)
        {
            Console.WriteLine($"{p.Name} | Active: {p.IsActive} | LastLogin: {p.LastLogin}");
        }

      
        var lowLevelPlayers = players
            .Where(p => p.Level < 10)
            .Select(p => new
            {
                p.Name,
                p.Level,
                p.Gold
            }).ToList();

        Console.WriteLine("\n== Danh sách người chơi cấp thấp (Level < 10) ==");
        foreach (var p in lowLevelPlayers)
        {
            Console.WriteLine($"{p.Name} | Level: {p.Level} | Gold: {p.Gold}");
        }
        var firebase = new FirebaseClient(firebaseUrl);
        await firebase.Child("final_exam_bai1_inactive_players").PutAsync(inactivePlayers);
        await firebase.Child("final_exam_bai1_low_level_players").PutAsync(lowLevelPlayers);

        Console.WriteLine("\n Dữ liệu đã được đẩy lên Firebase.");
    }
}
