using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BattingStatsApp.Data;
using BattingStatsApp.Models;

using static System.Math;

namespace BattingStatsApp.Pages.Battings;

public class BattingModel : PageModel
{
   private readonly BattingStatsApp.Data.BattingStatsDBContext _context;
   private readonly ILogger _logger;

   public BattingModel(ILogger<BattingModel> logger, BattingStatsApp.Data.BattingStatsDBContext context)
   {
      _context = context;
      _logger = logger;
   }

   public List<BattingUI> Batting { get; set; } = new();
   [BindProperty(SupportsGet = true)] public int CurrentYr { get; set; }
   [BindProperty(SupportsGet = true)] public string CurrentLg { get; set; }
   [BindProperty(SupportsGet = true)] public string CurrentSort { get; set; }

   public async Task OnGetAsync(int yr=2022, string lg="Both", string sort="")
   {
      _logger.LogInformation("In OnGetAsync");

      CurrentYr = yr;
      CurrentLg = lg;
      CurrentSort = sort;

      //try {
         IQueryable<BattingUI> battingIQ =
            from b in _context.Battings
            from m in _context.Masters
            where
               b.PlayerId == m.PlayerId &&
               (lg == b.LgId ||
               (lg == "Both" && (b.LgId == "NL" || b.LgId == "AL"))) &&
               b.YearId == yr &&
               (b.Ab >= 250 || (CurrentYr == 2020 && b.Ab >= 100))
            select new BattingUI() {
               PlayerId = m.PlayerId,
               PlayerName = m.NameLast + ", " + m.NameFirst + ", " + b.TeamId,
               Pa = (int)b.Pa!,
               Ab = b.Ab,
               R = b.R,
               H = b.H,
               Rbi = b.Rbi,
               Hr = b.Hr,
               Bb = b.Bb,
               Avg = Round(b.Ab > 0 ? (double)b.H / (double)b.Ab : 0.0, 3),
               OBP = Round(b.Ab > 0 ? (double)(b.H + (int)b.Bb!) / (double)(b.Ab + (int)b.Bb) : 0.0, 3),
               Slg = Round(b.Ab > 0 ? (double)(b.H + b._2b + 2 * b._3b + 3 * b.Hr) / (double)b.Ab : 0.0, 3)
            };

         Batting = CurrentSort switch {
           "Name"=> await battingIQ.OrderBy(e => e.PlayerName).ToListAsync(),
           "Avg" => await battingIQ.OrderByDescending(e => e.Avg).ToListAsync(),
            "OPS" => await battingIQ.OrderByDescending(e => e.OBP + e.Slg).ToListAsync(),
            "H"   => await battingIQ.OrderByDescending(e => e.H).ToListAsync(),
            "Ab"  => await battingIQ.OrderByDescending(e => e.Ab).ToListAsync(),
            "Hr"  => await battingIQ.OrderByDescending(e => e.Hr).ToListAsync(),
            "Rbi" => await battingIQ.OrderByDescending(e => e.Rbi).ToListAsync(),
            _ => await battingIQ.OrderByDescending(e => e.OBP + e.Slg).ToListAsync()
         };

         //Batting = await battingIQ.OrderByDescending(e => e.OBP + e.Slg).ToListAsync();
         Batting.ForEach(e => e.OPS = Round(e.OBP + e.Slg, 3));
      
   }

}
