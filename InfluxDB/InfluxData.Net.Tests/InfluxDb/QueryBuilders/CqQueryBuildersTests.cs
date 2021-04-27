using FluentAssertions;
using InfluxData.Net.InfluxDb.QueryBuilders;
 

namespace InfluxData.Net.Tests.InfluxDb.QueryBuilders
{
 
    public class CqQueryBuildersTests
    {
        public ICqQueryBuilder Sut { get; set; }

        public CqQueryBuildersTests()
        {
            this.Sut = new CqQueryBuilder();
        }

      
        public void GetCq_ShouldReturn_QueryStatement()
        {
            var query = this.Sut.GetContinuousQueries();

            query.Should().Be("SHOW CONTINUOUS QUERIES");
        }
    }
}
