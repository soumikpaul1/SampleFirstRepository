using System;
using SMM.Contract.Model;

namespace SMM.Services
{
    public class FacetsDataBaseConnectionBuilder : IDatabaseConnectionBuilder
    {
        private readonly IDatabaseSection _dbSection;

        public FacetsDataBaseConnectionBuilder(IDatabaseSection dbSection)
        {
            _dbSection = dbSection;
        }
        public string CreateConnectionString()
        {
            string connection;
            //TODO apply proper coding
            switch (_dbSection.Mode)
            {
                case DatabaseAuthenticationMode.Integrated:
                    connection = GenerateWindowsAuthenticationConnectionString();
                    break;
                case DatabaseAuthenticationMode.Database:
                    connection = GenerateDatabaseAuthenticationConnectionString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            return connection;
        }

        private string GenerateDatabaseAuthenticationConnectionString()
        {
            var connection = string.Empty;
            switch (_dbSection.Provider)
            {
                case DatabaseProviders.Oracle:
                    connection =
                        $@"Data Source={_dbSection.ServiceName};User Id={_dbSection.UserId},Password={
                                _dbSection.Password
                            };ConnectionTimeOut={_dbSection.ConnectionTimeOut}";
                    break;
                case DatabaseProviders.SqlServer:
                    connection = $@"Data Source";
                    break;
                case DatabaseProviders.Sybase:
                    connection = 
                        $@"Data Source = {_dbSection.ServiceName};User Id={_dbSection.UserId},Password={
                            _dbSection.Password
                        };ConnectionTimeOut={_dbSection.ConnectionTimeOut}";
                    break;
                case DatabaseProviders.None:
                    connection = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return connection;
        }

        private string GenerateWindowsAuthenticationConnectionString()
        {
            string connection;
            switch (_dbSection.Provider)
            {
                case DatabaseProviders.Oracle:
                    connection =
                        $@"Data Source={_dbSection.ServiceName};User Id={_dbSection.UserId};Password={
                                _dbSection.Password
                            };ConnectionTimeOut={_dbSection.ConnectionTimeOut}";
                    break;
                case DatabaseProviders.SqlServer:
                    //Check for port
                    connection = $@"Data Source={_dbSection.Server};Initial Catalog={_dbSection.Database};Trusted_Connection = true;";
                    break;
                case DatabaseProviders.Sybase:
                    connection = 
                        $@"Data Source = {_dbSection.ServiceName};User Id={_dbSection.UserId};Password={
                            _dbSection.Password
                        };ConnectionTimeOut={_dbSection.ConnectionTimeOut}";
                    break;
                case DatabaseProviders.None:
                    connection = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return connection;
        }

        public void Dispose()
        {
        }

        
    }
}
