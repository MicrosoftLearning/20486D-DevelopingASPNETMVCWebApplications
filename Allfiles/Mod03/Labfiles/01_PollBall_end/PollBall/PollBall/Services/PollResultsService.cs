using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollBall
{
    public class PollResultsService : IPollResultsService
    {
        private Dictionary<SelectedGame, int> selectionVotes { get; set; }

        public PollResultsService()
        {
            selectionVotes = new Dictionary<SelectedGame, int>();
        }

        public void AddVote(SelectedGame game)
        {
            if (selectionVotes.ContainsKey(game))
                selectionVotes[game]++;
            else
                selectionVotes.Add(game, 1);
        }

        public SortedDictionary<SelectedGame, int> GetVoteResult()
        {
            SortedDictionary<SelectedGame, int> sortedSelectionVotes = new SortedDictionary<SelectedGame, int>();

            foreach (KeyValuePair<SelectedGame, int> item in selectionVotes)
            {
                sortedSelectionVotes.Add(item.Key, item.Value);
            }
            return sortedSelectionVotes;
        }
    }
}
