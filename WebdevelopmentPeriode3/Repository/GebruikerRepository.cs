using System.Data;
using Dapper;
using WebdevelopmentPeriode3.Pages;

namespace WebdevelopmentPeriode3.Repository;

public class GebruikerRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public Gebruiker Get(int userId)
    {
        string sql = "SELECT * FROM gebruiker WHERE UserId = @userId";
            
        using var connection = GetConnection();
        var gebruiker = connection.QuerySingle<Gebruiker>(sql, new { userId });
        return gebruiker;
    }

    public List<Gebruiker> Get()
    {
        string sql = "SELECT * FROM Gebruiker ORDER BY Username";
            
        using var connection = GetConnection();
        var gebruikers = connection.Query<Gebruiker>(sql);
        return gebruikers.ToList();
    }
    
    public Gebruiker GetById(string username)
    {
        using var connection = GetConnection();
        var gebruiker = connection.QuerySingleOrDefault<Gebruiker>(
            sql: "SELECT * FROM Gebruiker WHERE Username = @Username",
            param: new {Username = username});
        return gebruiker;
    }
}