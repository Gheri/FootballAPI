using FootballAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Composition;
using System.Threading.Tasks;

namespace FootballAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        ITeamDataSource _teamDataSource;

        // teamDataSource is wrapper to talk to database
        public TeamsController([Import]ITeamDataSource dataSource)
        {
            _teamDataSource = dataSource;
        }

        // POST: /teams
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<TeamModel>> PostTeam(TeamModel team)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (team.Name == null || team.Name == string.Empty)
            {
                // invalid values for POST call
                return UnprocessableEntity("Values are incorrect");
            }

            if (_teamDataSource.GetTeam(team.Name) != null)
            {
                // already present team with same name
                return UnprocessableEntity("Already Team present with same name");
            }

            _teamDataSource.AddTeam(team);

            return CreatedAtAction(nameof(GetTeam), new { name = team.Name }, team);
        }

        // GET: teams/team_name
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeamModel>> GetTeam(string name)
        {
            var team = _teamDataSource.GetTeam(name);

            if (team == null)
            {
                return NotFound("No Team present with name " + name);
            }

            return team;
        }

        // GET: teams
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TeamModel>>> Get()
        {
            var teams = _teamDataSource.GetTeams();

            return Ok(teams);
        }

        // PUT: teams/name
        [HttpPut("{teamName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeamModel>> PutTeam(string teamName, TeamModel team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (teamName != team.Name)
            {
                return BadRequest();
            }

            if (_teamDataSource.GetTeam(teamName) ==  null)
            {
                return NotFound("No Team present with name " + teamName);
            }

            var updatedEntity = _teamDataSource.Update(team);

            // RFC Compliance return updated entity
            return updatedEntity;
        }
    }
}
