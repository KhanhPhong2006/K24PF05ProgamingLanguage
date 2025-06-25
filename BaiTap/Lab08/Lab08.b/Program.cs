using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Player
{
    public string PlayerID { get; set; }
    public string Name { get; set; }
    public int Gold { get; set; }
    public int Score { get; set; }
}

class Program
{
    static FirebaseClient firebase = new FirebaseClient("https://lab08-6a405-default-rtdb.firebaseio.com/");

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        await GetTopGoldPlayers();
        Console.WriteLine("Top 5 người chơi có Gold cao nhất đã được lưu vào node 'TopGold'.");
    }

    static async Task GetTopGoldPlayers()
    {
        var players = await firebase
            .Child("Players")
            .OnceAsync<Player>();

        var topPlayers = players
            .Select(p => p.Object)
            .OrderByDescending(p => p.Gold)
            .Take(5)
            .ToList();


        for (int i = 0; i < topPlayers.Count; i++)
        {
            await firebase
                .Child("TopGold")
                .Child((i + 1).ToString())  
                .PutAsync(topPlayers[i]);
        }
    }
}

