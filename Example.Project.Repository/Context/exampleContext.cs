using Example.Project.ToolKit.Settings;
using System.Data;

namespace Example.Project.Repository.Context
{
    public class exampleContext : IexampleContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;
        private readonly ISettingService _settingService;
       

        public exampleContext(ISettingService settingService)
        {
            _settingService = settingService;
            _connectionString = _settingService.GetConnectionString<string>("eDocumentConnStr");
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open) _connection.Open();
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
