using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

      //public List<BattingUI> Batting { get; set; } = new();
      [BindProperty(SupportsGet = true)] public int CurrentYr { get; set; }
      [BindProperty(SupportsGet = true)] public string CurrentLg { get; set; }
      public string CurrentSort { get; set; }
      public async Task OnGetAsync(int yr = 2021, string lg = "Both")
      {
         _logger.LogInformation("In OnGetAsync");

         CurrentYr = yr;
         CurrentLg = lg;
      }
   }

}
