using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStatsClient
{
    public class Player
    {
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Primary_Position { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Jersey_Number { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                 $"FirstName: {First_Name}\n" +
                 $"LastName: {Last_Name}\n" +
                 $"Position: {Primary_Position}\n";
        }
    }
}
