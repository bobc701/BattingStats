using BattingStatsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Math;

namespace BattingStatsApp.Pages.Battings
{
   public class PitchingModel : PageModel
   {
      private readonly BattingStatsApp.Data.BattingStatsDBContext _context;
      private readonly ILogger _logger;

      public PitchingModel(ILogger<PitchingModel> logger, BattingStatsApp.Data.BattingStatsDBContext context)
      {
         _context = context;
         _logger = logger;
      }

      public List<PitchingUI> Pitching { get; set; } = new();
      [BindProperty(SupportsGet = true)] public int CurrentYr { get; set; }
      [BindProperty(SupportsGet = true)] public string CurrentLg { get; set; }
      [BindProperty(SupportsGet = true)] public string CurrentSort { get; set; }


      public async Task OnGetAsync(int yr = 2022, string lg = "Both", string sort = "")
      {
         _logger.LogInformation("In OnGetAsync");

         CurrentYr = yr;
         CurrentLg = lg;
         CurrentSort = sort;

         /* G W L Sv IP So Era Whip */

         IQueryable<PitchingUI> pitchingIQ =
            from p in _context.Pitchings
            from m in _context.Masters
            where
               p.PlayerId == m.PlayerId &&
               (lg == p.LgId ||
               (lg == "Both" && (p.LgId == "NL" || p.LgId == "AL"))) &&
               p.YearId == yr &&
               (p.Ipouts >= 150 ||
               (CurrentYr == 2020 && p.Ipouts >= 60))
            select new PitchingUI() {
               PlayerId = m.PlayerId,
               PlayerName = m.NameLast + ", " + m.NameFirst + ", " + p.TeamId,
               G = p.G,
               W = p.W,
               L = p.L,
               Sv = p.Sv,
               So = p.So,
               Bb = p.Bb,
               Ipouts = p.Ipouts,
               Ip = 0.0,
               H = p.H,
               Era = Round(p.Ipouts > 0 ? p.Er / (p.Ipouts / 3.0) * 9.0 : 0.0, 2),
               Whip = Round(p.Ipouts > 0 ? (double)(p.H + p.Bb) / (double)(p.Ipouts / 3.0) : 0.0, 3)
            };

         Pitching = await pitchingIQ.ToListAsync();
         Pitching.ForEach(e => e.Ip = e.IpDisplay);

         Pitching = CurrentSort switch {
            "Name" => Pitching.OrderBy(e => e.PlayerName).ToList(),
            "Ip" => Pitching.OrderByDescending(e => e.Ip).ToList(),
            "G" => Pitching.OrderByDescending(e => e.G).ToList(),
            "W" => Pitching.OrderByDescending(e => e.W).ToList(),
            "L" => Pitching.OrderByDescending(e => e.L).ToList(),
            "Sv" => Pitching.OrderByDescending(e => e.Sv).ToList(),
            "Era" => Pitching.OrderBy(e => e.Era).ToList(),
            "Whip" => Pitching.OrderBy(e => e.Whip).ToList(),
            _ => Pitching.OrderBy(e => e.Era).ToList()
         };

   }
}

}
