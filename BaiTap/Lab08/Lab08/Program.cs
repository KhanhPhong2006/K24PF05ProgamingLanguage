using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

public class Player
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

        await AddPlayers();

       
        await DisplayAllPlayers();


        await UpdatePlayer("player3", gold: 999);

        await DeletePlayer("player5");

        Console.WriteLine("Done.");
        await GetTopGoldPlayers();
        Console.WriteLine("Top 5 người chơi có Gold cao nhất đã được lưu vào node 'TopGold'.");
        await GetTopScorePlayers();
        Console.WriteLine("Top 5 người chơi có Score cao nhất đã được lưu vào node 'TopScore'.");
    }

    static async Task AddPlayers()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var players = new List<Player>
        {
            new Player { PlayerID = "player1", Name = "Alice", Gold = 100, Score = 200 },
            new Player { PlayerID = "player2", Name = "Bob", Gold = 250, Score = 300 },
            new Player { PlayerID = "player3", Name = "Charlie", Gold = 150, Score = 400 },
            new Player { PlayerID = "player4", Name = "David", Gold = 400, Score = 100 },
            new Player { PlayerID = "player5", Name = "Eva", Gold = 80, Score = 250 },
            new Player { PlayerID = "player6", Name = "Frank", Gold = 310, Score = 310 },
            new Player { PlayerID = "player7", Name = "Grace", Gold = 220, Score = 150 },
            new Player { PlayerID = "player8", Name = "Henry", Gold = 95, Score = 175 },
            new Player { PlayerID = "player9", Name = "Ivy", Gold = 120, Score = 390 },
            new Player { PlayerID = "player10", Name = "Jack", Gold = 450, Score = 500 }
        };

        foreach (var player in players)
        {
            await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
        }

        Console.WriteLine("Đã thêm 10 người chơi.");
    }

    static async Task DisplayAllPlayers()
    {
        var players = await firebase.Child("Players").OnceAsync<Player>();

        Console.WriteLine("Danh sách người chơi:");
        foreach (var p in players)
        {
            var pl = p.Object;
            Console.WriteLine($"ID: {pl.PlayerID}, Name: {pl.Name}, Gold: {pl.Gold}, Score: {pl.Score}");
        }
    }

    static async Task UpdatePlayer(string playerId, int? gold = null, int? score = null)
    {
        var player = await firebase.Child("Players").Child(playerId).OnceSingleAsync<Player>();

        if (player == null)
        {
            Console.WriteLine("Không tìm thấy người chơi.");
            return;
        }

        if (gold != null) player.Gold = gold.Value;
        if (score != null) player.Score = score.Value;

        await firebase.Child("Players").Child(playerId).PutAsync(player);

        Console.WriteLine($"Đã cập nhật người chơi {playerId}.");
    }

    static async Task DeletePlayer(string playerId)
    {
        await firebase.Child("Players").Child(playerId).DeleteAsync();
        Console.WriteLine($"Đã xoá người chơi {playerId}.");
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
    static async Task GetTopScorePlayers()
    {
        var players = await firebase
            .Child("Players")
            .OnceAsync<Player>();
        var topPlayers = players
            .Select(p => p.Object)
            .OrderByDescending(p => p.Score)
            .Take(5)
            .ToList();
        for (int i = 0; i < topPlayers.Count; i++)
        {
            await firebase
                .Child("TopScore")
                .Child((i + 1).ToString())
                .PutAsync(topPlayers[i]);
        }
    }

}


