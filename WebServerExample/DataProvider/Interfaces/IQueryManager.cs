namespace WebServerExample.DataProvider.Interfaces
{
    public interface IQueryManager
    {
        public int ExecuteNonQuery(string SqlCommandText);
        public object[,] ExecuteQuery(string SqlCommandText);
    }
}
