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
    public string PlayerID { get; set; }
    public string Name { get; set; }
    public int Gold { get; set; }
    public int Score { get; set; }
    public int Coins { get; set; } 
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

                 var richPlayers = players
                .Where(p => p.Gold > 1000 && p.Coins > 100)
                .OrderByDescending(p => p.Gold)
                .Select(p => new
                {
                    p.Name,
                    p.Gold,
                    p.Coins
                })
                .ToList();

            Console.WriteLine("== Người chơi có Gold > 1000 & Coins > 100 ==");
            foreach (var p in richPlayers)
            {
                Console.WriteLine($"Name: {p.Name}, Gold: {p.Gold}, Coins: {p.Coins}");
            }

            var firebase = new FirebaseClient("https://lab11-34a73-default-rtdb.firebaseio.com/");
            await firebase
                .Child("quiz_bai1_richPlayers")
                .PutAsync(richPlayers);

            Console.WriteLine(">> Dữ liệu đã đẩy lên Firebase thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Lỗi: " + ex.Message);
        }
    }
}
