using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PollBall.Controllers
{
    public class HomeController : Controller
    {
        IPollResultsService pollResults;

        public HomeController(IPollResultsService pollResults)
        {
            this.pollResults = pollResults;
        }

        public IActionResult Index()
        {
            StringBuilder results = new StringBuilder();
            SortedDictionary<SelectedGame, int> voteLista = pollResults.GetVoteResult();

            foreach (var gameVotes in voteLista)
            {
                results.Append($"Game name: {gameVotes.Key}, Votes: {gameVotes.Value}{Environment.NewLine}");
            }

            return Content(results.ToString());
        }
    }
}