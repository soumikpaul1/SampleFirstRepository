using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMM.Configuration.ViewModels;
using SMM.Contract.Model;
using SMM.Contract.ViewModel;
using SMM.Domain.Application;
using SMM.Services;
using Xunit;
using Moq;
using Prism.Events;
using SMM.Configuration.Events;
using SMM.Contract.Data;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SMM.UI.Tests.ViewModels
{
    [TestClass()]
    public class FacetsDatabaseSectionViewModelTests
    {
        private Mock<IEventAggregator> _eventAggregatorMock;
        private Mock<ITestConnectionService> _testConnectionServiceMock;
        private FacetsDatabaseSectionViewModel _viewModel;
        private Mock<OnTestConnectionClickedEvent> _testConnectionClickMock;
        private string _testConnectionString = string.Empty;
        public FacetsDatabaseSectionViewModelTests()
        {
            _viewModel = new FacetsDatabaseSectionViewModel();
            _testConnectionClickMock = new Mock<OnTestConnectionClickedEvent>();
            _testConnectionServiceMock = new Mock<ITestConnectionService>();
            _eventAggregatorMock = new Mock<IEventAggregator>(MockBehavior.Default);
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OnTestConnectionClickedEvent>())
                .Returns(_testConnectionClickMock.Object);
            _testConnectionServiceMock.Setup(
                tc => tc.TestConnection(_testConnectionString)).ReturnsAsync(true);

        }

        [Fact]
        public void TestConnectionShouldPassForValidConnectionString()
        {
            //Arrange 
            _testConnectionString = "Data Source=.;Initial Catalog=Northwind;TrustedConnection=true;";
           _testConnectionServiceMock.Verify(tc => tc.TestConnection(_testConnectionString),Times.Once);
        }
    }



}