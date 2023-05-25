using System.Data;
using Dapper;

namespace WebdevelopmentPeriode3.Repository;

public class CategoryRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    public List<Category> Get()
    {
        string sql = $"SELECT * FROM category";
        using var connection = GetConnection();
        return connection.Query<Category>(sql).ToList();
    }
    
    
    
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}