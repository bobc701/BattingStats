using System;
using System.Collections.Generic;

namespace BattingStatsApp.Models
{
    public partial class Batting
    {
        public string PlayerId { get; set; } = null!;
        public int YearId { get; set; }
        public int Stint { get; set; }
        public string TeamId { get; set; } = null!;
        public string? LahmanId { get; set; }
        public string LgId { get; set; } = null!;
        public int G { get; set; }
        public int? Pa { get; set; }
        public int Ab { get; set; }
        public int R { get; set; }
        public int H { get; set; }
        public int _2b { get; set; }
        public int _3b { get; set; }
        public int Hr { get; set; }
        public int? Rbi { get; set; }
        public int? Sb { get; set; }
        public int? Cs { get; set; }
        public int? Bb { get; set; }
        public int? So { get; set; }
        public int? Ibb { get; set; }
        public int? Hbp { get; set; }
        public int? Sh { get; set; }
        public int? Sf { get; set; }
        public int? Gidp { get; set; }
        public string? PosSummary { get; set; }
    }
}
