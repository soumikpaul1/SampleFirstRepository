using System;
using SMM.Contract.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SMM.Domain.Application
{
    public sealed class FacetsDatabaseSection : IDatabaseSection
    {
        private DatabaseAuthenticationMode _mode;
        private string _commandTimeOut = "300";
        private string _connectionTimeOut = "30";
        private string _database;
        private string _password;
        private string _port;
        private DatabaseProviders _provider;
        private string _server;
        private string _serviceName;
        private string _userId;

        public DatabaseAuthenticationMode Mode {
            get { return _mode; }
            set
            {
                _mode = value;
                NotifyPropertyChanged();
            }
        }
        public string CommandTimeOut
        {
            get { return _commandTimeOut; }

            set
            {
                _commandTimeOut = value;
                NotifyPropertyChanged();
            }
        }

        public string ConnectionTimeOut
        {
            get { return _connectionTimeOut; }

            set
            {
                _connectionTimeOut = value;
                NotifyPropertyChanged();
            }
        }

        public string Database
        {
            get { return _database; }

            set
            {
                _database = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public string Port
        {
            get { return _port; }

            set
            {
                _port = value;
                NotifyPropertyChanged();
            }
        }

        public DatabaseProviders Provider
        {
            get { return _provider; }

            set
            {
                _provider = value;
                NotifyPropertyChanged();
            }
        }

        public string Server
        {
            get { return _server; }

            set
            {
                _server = value;
                NotifyPropertyChanged();
            }
        }

        public string ServiceName
        {
            get { return _serviceName; }

            set
            {
                _serviceName = value;
                NotifyPropertyChanged();
            }
        }

        public string UserId
        {
            get { return _userId; }

            set
            {
                _userId = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
