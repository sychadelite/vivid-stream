using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DapperContext
{
    private readonly string connectionString;

    public DapperContext()
    {
        this.connectionString = ConfigurationManager.AppSettings["MyDB"];
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(this.connectionString);
    }
}