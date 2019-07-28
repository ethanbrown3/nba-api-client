using System;
using System.Collections.Generic;
using System.Text;

namespace NbaStatsClient
{
    public class NbaTeamRepo
    {
        private Dictionary<string, NbaTeam> NbaTeams { get; set; }

        public NbaTeamRepo(List<NbaTeam> nbaTeams)
        {
            foreach (NbaTeam team in nbaTeams)
            {
                NbaTeams.Add(team.Id, team);
            }
        }
    }
}
