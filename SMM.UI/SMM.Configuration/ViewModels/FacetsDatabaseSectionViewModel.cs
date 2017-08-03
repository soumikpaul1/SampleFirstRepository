using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SMM.Contract.Model;
using SMM.Contract.ViewModel;
using SMM.Domain.Application;
using SMM.Services;
using Prism.Events;
using SMM.Configuration.Command;
using SMM.Configuration.Events;
using SMM.Contract.Data;

namespace SMM.Configuration.ViewModels
{
    public class FacetsDatabaseSectionViewModel : ViewModelBase, IDatabaseSectionViewModel
    {
        private readonly Func<IDatabaseConnectionBuilder> _connectionBuilderCreator;
        private readonly IEventAggregator _eventAggregator = new EventAggregator();
        private readonly ITestConnectionService _connectionService;
        private bool _isOracleProvider = false;



        public FacetsDatabaseSectionViewModel()
        {
            DbSection = GetFacetsDatabaseSection();
            _connectionBuilderCreator = () => new FacetsDataBaseConnectionBuilder(DbSection);
            OnDatabaseProviderSelectionChangedCommand = new DelegateCommand(OnDatabaseProviderSelctionChangedExecute);
            OnResetButtonClickedCommand = new DelegateCommand(OnResetButtonCLickedCommandExecute);
            OnTestConnectionClickedCommand = new DelegateCommand(OnTestConnectionClickCommandExecute);
            _eventAggregator.GetEvent<OnDatabaseProviderSelectionChangedEvent>()
                .Subscribe(OnDatabaseProviderSelctionChanged);
            _eventAggregator.GetEvent<OnResetButtonClickedEvent>().Subscribe(OnResetButtonClickExecute);
            _eventAggregator.GetEvent<OnTestConnectionClickedEvent>().Subscribe(OnTestConnectionClickExecute);
            _connectionService = new TestConectionService("System.Data.SqlClient");
        }

        #region <<Commands Declaration>>
        public ICommand OnDatabaseProviderSelectionChangedCommand { get; private set; }

        public ICommand OnResetButtonClickedCommand { get; private set; }

        public ICommand OnTestConnectionClickedCommand { get; private set; }

        #endregion

        #region <<Properties>>
        public bool IsOracleProvider
        {
            get { return _isOracleProvider; }
            set
            {
                _isOracleProvider = value;
                OnPropertyChanged();
            }
        }

        public IDatabaseSection DbSection { get; } 
        #endregion

        #region <<Event Subscription>>
        private void OnResetButtonClickExecute(IDatabaseSection databaseSection)
        {
            Reset();
        }

        private void OnDatabaseProviderSelctionChanged(DatabaseProviders obj)
        {
            IsOracleProvider = obj == DatabaseProviders.Oracle;
        }

        private void OnTestConnectionClickExecute()
        {
            try
            {
                var result = new TaskFactory<bool>().StartNew(() =>
                   {
                       var testConnectionResult = TestConnectionAsync();
                       return testConnectionResult.Result;
                   });
                MessageBox.Show(result.Result ? "Test Connection Successful" : "Test Connection Failed");
            }
            catch (AggregateException aggregateException)
            {
                var exceptions = aggregateException.Flatten();
                var sb = new StringBuilder();
                foreach (var ex in exceptions.InnerExceptions)
                {
                    sb.AppendLine(ex.Message);
                }
                MessageBox.Show(sb.ToString());
            }
        }
        #endregion

        #region <<Event Publishing>>
        private void OnTestConnectionClickCommandExecute(object obj)
        {
            _eventAggregator.GetEvent<OnTestConnectionClickedEvent>().Publish();
        }

        private void OnDatabaseProviderSelctionChangedExecute(object obj)
        {
            _eventAggregator.GetEvent<OnDatabaseProviderSelectionChangedEvent>().Publish(DbSection.Provider);
        }

        private void OnResetButtonCLickedCommandExecute(object obj)
        {
            _eventAggregator.GetEvent<OnResetButtonClickedEvent>().Publish(DbSection);
        }
        #endregion


        private IDatabaseSection GetFacetsDatabaseSection()
        {
            return new FacetsDatabaseSection()
            {
                Mode = DatabaseAuthenticationMode.Integrated,
                Provider = DatabaseProviders.SqlServer,
                ServiceName = string.Empty,
                Password = string.Empty,
                ConnectionTimeOut = "30",
                UserId = string.Empty,
                Port = string.Empty,
                Server = "(local)",
                Database = "Northwind",
                CommandTimeOut = "300"
            };
        }

        private async Task<bool> TestConnectionAsync()
        {
            using (var connectionBuilder = _connectionBuilderCreator())
            {
                var connection = connectionBuilder.CreateConnectionString();
                return await new TaskFactory<bool>().StartNew(() =>
                {
                    var testConnectionResult = _connectionService.TestConnection(connection);
                    return testConnectionResult.Result;
                });
            }

        }

        private Task<bool> Save()
        {
            return new Task<bool>(() => true);
        }

        private void Reset()
        {

            DbSection.CommandTimeOut = "300";
            DbSection.ConnectionTimeOut = "30";
            DbSection.Database = string.Empty;
            DbSection.Password = string.Empty;
            DbSection.Port = string.Empty;
            DbSection.Provider = DatabaseProviders.None;
            DbSection.Server = string.Empty;
            DbSection.ServiceName = string.Empty;
            DbSection.UserId = string.Empty;
        }
    }
}
