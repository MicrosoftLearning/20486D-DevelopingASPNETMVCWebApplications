using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollBall.Services
{
    public class PollResultsService : IPollResultsService
    {
        private Dictionary<SelectedGame, int> SelectionVotes { get; set; }

        public PollResultsService()
        {
            SelectionVotes = new Dictionary<SelectedGame, int>();
        }

        public void AddVote(SelectedGame game)
        {
            if (SelectionVotes.ContainsKey(game))
                SelectionVotes[game]++;
            else
                SelectionVotes.Add(game, 1);
        }

        public SortedDictionary<SelectedGame, int> GetVoteResult()
        {
            SortedDictionary<SelectedGame, int> sortedSelectionVotes = new SortedDictionary<SelectedGame, int>();
            foreach (KeyValuePair<SelectedGame, int> item in SelectionVotes)
            {
                sortedSelectionVotes.Add(item.Key, item.Value);
            }
            return sortedSelectionVotes;
        }
    }
}
