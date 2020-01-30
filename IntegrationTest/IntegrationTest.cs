using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTest
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<FootballAPI.Startup>>
    {
        private readonly WebApplicationFactory<FootballAPI.Startup> _factory;

        public IntegrationTest(WebApplicationFactory<FootballAPI.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/teams")]
        public async Task Get_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var clientOptions = new WebApplicationFactoryClientOptions();
            clientOptions.AllowAutoRedirect = true;
            clientOptions.BaseAddress = new System.Uri("http://localhost:3000");
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // registering mock data source which will fetch data from testData.json
                    services.Add(new ServiceDescriptor(typeof(FootballAPI.Models.ITeamDataSource), new MockTeamDataSource()));
                });
            }).CreateClient(clientOptions);

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200

            //todo verify content count is 2 as dummy data source has two records
        }
    }

    // for mocking data for integration
    public class MockTeamDataSource: FootballAPI.Models.TeamDataSource
    {
        public MockTeamDataSource() {
            LoadTeams(@"testData.json");
        }
    }
}
