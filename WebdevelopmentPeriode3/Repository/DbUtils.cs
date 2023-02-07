using System.Data;
using MySql.Data.MySqlClient;

namespace WebdevelopmentPeriode3.Repository;

public class DbUtils
{
    public DbUtils()
    {
    }
        
    public IDbConnection GetDbConnection()
    {
        string connectionString = Program.Configuration
            .GetConnectionString("WebdevCourseRazorPages.Exercises.MySQL")!;

        return new MySqlConnection(connectionString);
    }
}