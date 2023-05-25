using System.Data;
using Dapper;
using WebdevelopmentPeriode3.Pages;

namespace WebdevelopmentPeriode3.Repository;

public class RegisterRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public int Insert(String Username, string Password, string Mail)
    {
        string sql = "INSERT INTO gebruiker (Username, Password, Mail) VALUES (@Username, @Password, @Mail)";
            
        using var connection = GetConnection();
        var gebruiker = connection.Execute(sql, new { Username, Password, Mail });
        return gebruiker;
    }
}

