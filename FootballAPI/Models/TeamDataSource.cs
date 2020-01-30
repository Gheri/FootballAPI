using System;
using System.Collections.Generic;

using System.Composition;
using System.Linq;

namespace FootballAPI.Models
{
    [Export(typeof(ITeamDataSource))]
    // The purpose of this class is to fetch the data from data source
    public class TeamDataSource : ITeamDataSource
    {
        private IList<TeamModel> _teams = new List<TeamModel>();

        public TeamDataSource()
        {
            LoadTeams(@"data.json");
        }

        public void AddTeam(TeamModel team)
        {
            team.CreatedAt = Utilities.GetDateTimeStringInISO8601(DateTime.UtcNow);
            // for now hardcoding
            // it can be derived from authToken or client credentials
            team.CreatedBy = "Gheri.Rupchandani@gmail.com";

            _teams.Add(team);
        }

        public TeamModel GetTeam(string teamName)
        {
            // firstOrdefault returns null if teamName not found
            return _teams.Where(x => x.Name == teamName).FirstOrDefault();
        }

        public IEnumerable<TeamModel> GetTeams()
        {
            return _teams;
        }

        public TeamModel Update(TeamModel team)
        {
            var existingEntity = _teams.Where(x => x.Name == team.Name).FirstOrDefault();

            if(existingEntity != null)
            {
                existingEntity.Img = team.Img;
                existingEntity.ModifiedAt = Utilities.GetDateTimeStringInISO8601(DateTime.UtcNow);

                // for now hardcoding 
                // it should be derived from authToken passed in header or client credentials
                existingEntity.ModifiedBy = "Gheri.Rupchandani@gmail.com";
            }

            return existingEntity;
        }

        // keeping protected so that child classes can override for mocking data source in integration testing
        protected void LoadTeams(string fileName)
        {
            _teams = Utilities.GetData<List<TeamModel>>(fileName);
            
            //todo temp code to set createdAt in ISO-8061 date time
            foreach(var team in _teams)
            {
                team.CreatedAt = Utilities.GetDateTimeStringInISO8601(DateTime.UtcNow);
                team.CreatedBy = "Gheri.Rupchandani@gmail.com";
            }
        }
    }
}
