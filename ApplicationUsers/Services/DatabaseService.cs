using ApplicationUsers.Interfaces;
using Dapper;
using MySqlConnector;

namespace ApplicationUsers.Services
{
    public class DatabaseService: IDatabaseService 
    {
        private readonly MySqlConnection _DatabaseConnection;
        public DatabaseService(MySqlConnection DatabaseConnection) 
        { 
            _DatabaseConnection = DatabaseConnection;
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            return await _DatabaseConnection.ExecuteAsync(sql, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            return await _DatabaseConnection.QueryAsync<T>(sql, parameters);
        }
    }
}
