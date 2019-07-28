using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStatsClient
{
    public class NbaTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public string Alias { get; set; }
        public string Founded { get; set; }

        public List<Player> Players { get; set; }

        public override string ToString()
        {
            
            var playerList = new List<string>();
            foreach (Player player in Players)
            {
                playerList.Add(player.ToString());
            }
            string toString = $"ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Market: {Market}\n" +
                $"Alias: {Alias}\n" +
                $"Founded: {Founded}\n" +
                $"Players: {string.Join("\n", playerList)}";

            return toString;
        }
    }
}
