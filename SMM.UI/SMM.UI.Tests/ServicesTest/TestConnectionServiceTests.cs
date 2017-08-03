using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SMM.Contract.Data;
using Xunit;
using SMM.Services;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SMM.UI.Tests.ServicesTest
{
    [TestClass]
    public class TestConnectionServiceTests
    {
        private readonly Mock<ITestConnectionService> _testConnectionServiceMock;
        private  TestConnectionClass _testConnectionClass;

        public TestConnectionServiceTests()
        {
            _testConnectionServiceMock = new Mock<ITestConnectionService>();
           
        }

        [Fact]
        public void ShouldConnectToDatabaseForProperSqlServerConnectionString()
        {
            //Arrange
            const string connectionString = "Data Source=.;Initial Catalog=NorthWind;Trusted_Connection = true;";
            _testConnectionServiceMock.Setup(tc => tc.TestConnection(connectionString))
                .ReturnsAsync(new TestConectionService("System.Data.SqlClient").TestConnection(connectionString).Result).Verifiable();
            _testConnectionClass = new TestConnectionClass(_testConnectionServiceMock.Object,connectionString);

            //Act
            var result = _testConnectionClass.TestConnection().Result;

            //Assert
            _testConnectionServiceMock.Verify();
            Assert.AreEqual(result, true);

        }
    }

    public class TestConnectionClass
    {
        private readonly ITestConnectionService _testConnectionService;
        private readonly string _connectionString;
        public TestConnectionClass(ITestConnectionService testConnectionService, string connectionString)
        {
            _testConnectionService = testConnectionService;
            _connectionString = connectionString;
        }

        public async Task<bool> TestConnection()
        {
            return await _testConnectionService.TestConnection(_connectionString);
        }
    }
}
