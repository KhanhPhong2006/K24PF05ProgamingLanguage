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
    public int Level { get; set; }
    public int Gold { get; set; }
}

public class AwardedPlayer
{
    public string Name { get; set; }
    public int VipLevel { get; set; }
    public int Level { get; set; }
    public int CurrentGold { get; set; }
    public int AwardedGold { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(url);
        var players = JsonConvert.DeserializeObject<List<Player>>(json);
        var top3 = players
            .Where(p => p.VipLevel > 0)
            .OrderByDescending(p => p.Level)
            .ThenByDescending(p => p.VipLevel)
            .Take(3)
            .Select((p, index) => new AwardedPlayer
            {
                Name = p.Name,
                VipLevel = p.VipLevel,
                Level = p.Level,
                CurrentGold = p.Gold,
                AwardedGold = index == 0 ? 2000 : index == 1 ? 1500 : 1000
            })
            .ToList();

        Console.WriteLine("Top 3 VIP Players with Awarded Gold:");
        foreach (var p in top3)
        {
            Console.WriteLine($"Name: {p.Name}, VIP: {p.VipLevel}, Level: {p.Level}, Current Gold: {p.CurrentGold}, Awarded Gold: {p.AwardedGold}");
        }

        var firebase = new FirebaseClient("https://lab12-79466-default-rtdb.asia-southeast1.firebasedatabase.app/");
        await firebase
            .Child("final_exam_bai2_top3_vip_awards")
            .PutAsync(top3);

        Console.WriteLine("Top 3 VIP đã được push lên Firebase.");
    }
}
