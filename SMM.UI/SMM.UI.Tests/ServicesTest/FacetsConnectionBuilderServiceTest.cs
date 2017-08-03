using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMM.Contract.Model;
using SMM.Domain.Application;
using SMM.Services;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SMM.UI.Tests.ServicesTest
{
    [TestClass]
    public class FacetsConnectionBuilderServiceTest
    {
        private readonly Mock<IDatabaseConnectionBuilder> _connectionBuilderMock;

        public FacetsConnectionBuilderServiceTest()
        {
            _connectionBuilderMock = new Mock<IDatabaseConnectionBuilder>();
        }

        [Fact]
        public void ShouldCreateAProperConnectionString()
        {
            //Arrange
           IDatabaseSection dbSection = new FacetsDatabaseSection()
           {
               Provider = DatabaseProviders.SqlServer,
               ServiceName = string.Empty,
               Password = string.Empty,
               ConnectionTimeOut = "30",
               UserId = "pauls",
               Port = "44000",
               Database = "NorthWind",
               Server = ".",
               CommandTimeOut = "300",
               Mode = DatabaseAuthenticationMode.Integrated
           };
            _connectionBuilderMock.Setup(cb => cb.CreateConnectionString())
                .Returns(new FacetsDataBaseConnectionBuilder(dbSection).CreateConnectionString());

            var result = new FacetsConnectionBuilderTestClass(_connectionBuilderMock.Object).CreateConnection();

            //Assert
            _connectionBuilderMock.Verify();
            Assert.AreEqual(result, "Data Source=.;Initial Catalog=NorthWind;Trusted_Connection = true;");

        }
        
       
    }

    public class FacetsConnectionBuilderTestClass
    {
        private readonly IDatabaseConnectionBuilder _databaseConnectionBuilder;
        
        public FacetsConnectionBuilderTestClass(IDatabaseConnectionBuilder databaseConnectionBuilder)
        {
            _databaseConnectionBuilder = databaseConnectionBuilder;
           
        }

        public string CreateConnection()
        {
            return _databaseConnectionBuilder.CreateConnectionString();
        }
    }
}
