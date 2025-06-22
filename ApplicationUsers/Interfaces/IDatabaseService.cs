namespace ApplicationUsers.Interfaces
{
    public interface IDatabaseService
    {
        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
        public Task<int> ExecuteAsync( string sql, object? parameters = null);  
    }
}
