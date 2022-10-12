using System.ComponentModel.DataAnnotations;
using static System.Math;

namespace BattingStatsApp.Models
{
   public class BattingUI
   {
      public string PlayerId { get; set; } = null!;
      [Display(Name = "Player")] 
      public string PlayerName { get; set; } = null!; // From Master
      public int YearId { get; set; }
      public int Stint { get; set; }
      public string TeamId { get; set; } = null!;
      public string LgId { get; set; } = null!;
      public int G { get; set; }
      public int Ab { get; set; }
      public int R { get; set; }
      public int H { get; set; }
      public int _2b { get; set; }
      public int _3b { get; set; }
      public int Hr { get; set; }
      public int? Rbi { get; set; }
      public int? Bb { get; set; }
      public double Avg { get; set; }
      public double OBP { get; set; }
      public double Slg { get; set; }
      public double OPS { get; set; }

      //public double Avg => Ab > 0 ? (double)H / (double)Ab : 0.0;
      //public double OBP => Ab > 0 ? (double)(H + (int)Bb!) / (double)(Ab + (int)Bb) : 0.0;
      //public double Slg => Ab > 0 ? (double)(H + _2b + 2*_3b + 3*Hr) / (double)Ab : 0.0;
      //public double OPS => OBP + Slg;
   }
}
