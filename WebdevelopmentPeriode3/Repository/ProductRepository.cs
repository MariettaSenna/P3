using System.Data;
using Dapper;
using WebdevelopmentPeriode3.Pages.Ober;

namespace WebdevelopmentPeriode3.Repository;

public class ProductRepository
{

    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
    
    
    public List<Product> Get(int categoryId)
    {
        throw new NotImplementedException();
    }
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}