using System.Collections.Generic;

namespace FootballAPI.Models
{
    // The contract for TeamDataSource. TeamDataSource is wrapper for Db calls
    public interface ITeamDataSource
    {
        /// <summary>
        /// returns team model with given name
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        TeamModel GetTeam(string teamName);

        /// <summary>
        /// returns all the teams
        /// </summary>
        /// <returns></returns>
        IEnumerable<TeamModel> GetTeams();

        /// <summary>
        /// Add team model in database
        /// </summary>
        /// <param name="team"></param>
        void AddTeam(TeamModel team);

        /// <summary>
        /// Updates the team model in database
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        TeamModel Update(TeamModel team);
    }
}
