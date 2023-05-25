using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Mysqlx.Crud;
using WebdevelopmentPeriode3.Models;
using WebdevelopmentPeriode3.Pages;

namespace WebdevelopmentPeriode3.Repository;

public class OrderLineRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public int Get (int ProductId, int TableId, int Amount, int AmountPaid)
    {
        string sql = "SELECT TRUE FROM OrderLine WHERE TableId = @TableId AND ProductId = @ProductId";
        using var connection = GetConnection();
        var product = connection.Execute(sql, param: new {ProductId, TableId, Amount, AmountPaid });
        return product;
    }

    public List<ProductOverzicht> GetOverzicht(int TableId)
    {
        string sql = @"SELECT product.Name, product.Price, orderline.Amount, orderLine.ProductId, orderLine.TableId
        FROM product  INNER JOIN  orderline ON product.ProductId = orderline.ProductId
        WHERE orderline.TableId = @TableId";
        using var connection = GetConnection();
        return connection.Query<ProductOverzicht>(sql, new {TableId}).ToList();
    }

    public void Order(int ProductId, int TableId, int AmountAdd)
    {
        var connection = GetConnection();
        string sql;
        
        int sqlok = (int)connection.ExecuteScalar<int>($@"SELECT Amount FROM orderline WHERE TableId = @TableId AND ProductId = @ProductId",
        new {ProductId,  TableId});

        int newAmount = sqlok + AmountAdd;
        if (newAmount > 0)
        {
            sql = @"Update orderline SET Amount = Amount + @AmountAdd WHERE ProductId = @ProductId AND TableId = @TableId";
        }
        else if (newAmount <= 0)
        {
            sql = @"DELETE FROM orderLine WHERE ProductId = @ProductId AND TableId = @TableId";
        }
        else
        {
            sql = @"INSERT INTO orderLine (TableId, ProductId, Amount, AmountPaid) VALUES (@TableId, @ProductId, 1, 0)";
        }

        var execute = connection.Execute(sql, new {TableId, ProductId, AmountAdd});
    }
    
    // Als er nog niks inzit wordt er een toegevoegd bij else.
    
    

    public class ProductOverzicht
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public int TableId { get; set; }
    }
}