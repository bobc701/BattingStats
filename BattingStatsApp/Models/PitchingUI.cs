using System.ComponentModel.DataAnnotations;

namespace BattingStatsApp.Models
{
   public class PitchingUI
   {
      public string PlayerId { get; set; } = null!;

      [Display(Name = "Pitcher")]
      public string PlayerName { get; set; } = null!; // From Master
      public int YearId { get; set; }
      public int Stint { get; set; }
      public string TeamId { get; set; } = null!;
      public string LgId { get; set; } = null!;
      public int W { get; set; }
      public int L { get; set; }
      public int G { get; set; }
      public int Gs { get; set; }
      public int Cg { get; set; }
      public int Sho { get; set; }
      public int Sv { get; set; }
      public int Ipouts { get; set; }
      public double Ip { get; set; } // Calc'd in Action.
      public int H { get; set; }
      public int Er { get; set; }
      public int Hr { get; set; }
      public int Bb { get; set; }
      public int So { get; set; }
      public double? Baopp { get; set; }
      public double? Era { get; set; }
      public double? Whip { get; set; } // Cal'd in action
      public int? Ibb { get; set; }
      public int? Wp { get; set; }
      public int? Hbp { get; set; }
      public int? Bk { get; set; }
      public int? Bfp { get; set; }
      public int? Gf { get; set; }
      public int? R { get; set; }
      public int? Sh { get; set; }
      public int? Sf { get; set; }

      public double IpDisplay {
         get {
            double ip = Ipouts / 3.0;
            double n = System.Math.Truncate(ip);
            int d = (int)(10.0 * (ip - n));
            //string s = n.ToString();
            return d switch {
               0 => n,
               3 => n + 0.1,
               6 => n + 0.2,
               _ => 0.0
            };
         }

      }

   }

}

