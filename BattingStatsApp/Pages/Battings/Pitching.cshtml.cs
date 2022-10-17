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
      public string CurrentSort { get; set; }


      public async Task OnGetAsync(int yr = 2021, string lg = "Both")
      {
         _logger.LogInformation("In OnGetAsync");

         CurrentYr = yr;
         CurrentLg = lg;

         /* G W L Sv IP So Era Whip */

         IQueryable<PitchingUI> pitchingIQ =
            from p in _context.Pitchings
            from m in _context.Masters
            where
               p.PlayerId == m.PlayerId &&
               (p.LgId == lg || lg == "Both") &&
               p.YearId == yr &&
               (p.Ipouts >= 300 || (CurrentYr == 2020 && p.Ipouts >= 100))
            select new PitchingUI() {
               PlayerId = m.PlayerId,
               PlayerName = $"{m.NameLast}, {m.NameFirst}, {p.TeamId}",
               G = p.G,
               W = p.W,
               L = p.L,
               Sv = p.Sv,
               So = p.So,
               Bb = p.Bb,
               Era = p.Era,
            };


         Pitching = await pitchingIQ.OrderByDescending(e => e.Era).ToListAsync();
         Pitching.ForEach(p => {
            p.Ip = Round(p.Ipouts / 3.0, 1);
            p.Whip = Round(p.Ipouts > 0 ? (double)(p.H + p.Bb) / (double)(p.Ipouts / 3.0) : 0.0, 3);
         });
   }
}

}
