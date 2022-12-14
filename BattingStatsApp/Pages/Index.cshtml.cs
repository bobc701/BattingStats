using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattingStatsApp.Pages
{
   public class IndexModel : PageModel
   {
      private readonly ILogger<IndexModel> _logger;

      public IndexModel(ILogger<IndexModel> logger)
      {
         _logger = logger;
      }

      public ActionResult OnGet()
      {
         return RedirectToPage("/Battings/Batting", new { yr = 2022, lg = "Both" });
      }
   }
}