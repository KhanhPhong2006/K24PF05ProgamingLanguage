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
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        await AddPlayers();
        Console.WriteLine("====== Đã thêm 10 người chơi ======\n");

        await DisplayAllPlayers();

        await UpdatePlayerFromConsole();
        Console.WriteLine("\n====== Đã cập nhật người chơi từ console ======\n");


        await DeletePlayerFromConsole();
        Console.WriteLine("\n====== Đã xoá người chơi từ console ======\n");

        await AddSinglePlayerFromConsole();
        Console.WriteLine("\n====== Đã thêm người chơi mới từ console ======\n");

        Console.WriteLine("\n====== Top 5 người chơi có Gold cao nhất ======\n");
        await GetTopGoldPlayers();

        Console.WriteLine("\n====== Top 5 người chơi có Score cao nhất ======\n");
        await GetTopScorePlayers();

        Console.WriteLine("\nHoàn thành tất cả thao tác.");
    }

    static async Task AddPlayers()
    {
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
    }

    static async Task DisplayAllPlayers()
    {
        var players = await firebase.Child("Players").OnceAsync<Player>();

        Console.WriteLine("Danh sách người chơi:");
        foreach (var p in players)
        {
            var pl = p.Object;
            Console.WriteLine($"ID: {pl.PlayerID}, Tên: {pl.Name}, Gold: {pl.Gold}, Score: {pl.Score}");
        }
    }

    static async Task UpdatePlayerFromConsole()
    {
        Console.Write("Nhập PlayerID cần cập nhật: ");
        string playerId = Console.ReadLine();

        var player = await firebase.Child("Players").Child(playerId).OnceSingleAsync<Player>();

        if (player == null)
        {
            Console.WriteLine("Không tìm thấy người chơi.");
            return;
        }

        Console.Write("Cập nhật Gold mới (hoặc để trống nếu không đổi): ");
        string goldInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(goldInput) && int.TryParse(goldInput, out int newGold))
        {
            player.Gold = newGold;
        }

        Console.Write("Cập nhật Score mới (hoặc để trống nếu không đổi): ");
        string scoreInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(scoreInput) && int.TryParse(scoreInput, out int newScore))
        {
            player.Score = newScore;
        }

        await firebase.Child("Players").Child(playerId).PutAsync(player);
        Console.WriteLine($"Đã cập nhật thông tin người chơi {player.Name}.");
    }


    static async Task DeletePlayerFromConsole()
    {
        Console.Write("Nhập PlayerID cần xoá: ");
        string playerId = Console.ReadLine();

        var player = await firebase.Child("Players").Child(playerId).OnceSingleAsync<Player>();

        if (player == null)
        {
            Console.WriteLine("Không tìm thấy người chơi để xoá.");
            return;
        }

        await firebase.Child("Players").Child(playerId).DeleteAsync();
        Console.WriteLine($"Đã xoá người chơi có ID: {playerId}");
    }

    static async Task AddSinglePlayerFromConsole()
    {
        Console.WriteLine("Nhập thông tin người chơi mới:");

        Console.Write("PlayerID: ");
        string id = Console.ReadLine();

        Console.Write("Tên: ");
        string name = Console.ReadLine();

        Console.Write("Gold: ");
        int gold = int.Parse(Console.ReadLine());

        Console.Write("Score: ");
        int score = int.Parse(Console.ReadLine());

        var player = new Player
        {
            PlayerID = id,
            Name = name,
            Gold = gold,
            Score = score
        };

        await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
        Console.WriteLine("Đã thêm người chơi mới thành công.");
    }


    static async Task GetTopGoldPlayers()
    {
        var players = await firebase.Child("Players").OnceAsync<Player>();
        var topPlayers = players
            .Select(p => p.Object)
            .OrderByDescending(p => p.Gold)
            .Take(5)
            .ToList();

        for (int i = 0; i < topPlayers.Count; i++)
        {
            await firebase.Child("TopGold").Child((i + 1).ToString()).PutAsync(topPlayers[i]);
            Console.WriteLine($"Hạng {i + 1}: {topPlayers[i].Name} - Gold: {topPlayers[i].Gold}");
        }
    }

    static async Task GetTopScorePlayers()
    {
        var players = await firebase.Child("Players").OnceAsync<Player>();
        var topPlayers = players
            .Select(p => p.Object)
            .OrderByDescending(p => p.Score)
            .Take(5)
            .ToList();

        for (int i = 0; i < topPlayers.Count; i++)
        {
            await firebase.Child("TopScore").Child((i + 1).ToString()).PutAsync(topPlayers[i]);
            Console.WriteLine($"Hạng {i + 1}: {topPlayers[i].Name} - Score: {topPlayers[i].Score}");
        }
    }
}


