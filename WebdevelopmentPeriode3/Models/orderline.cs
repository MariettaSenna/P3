namespace WebdevelopmentPeriode3.Models;

public class orderline
{
    public int ProductId { get; set; }
    public int TableId { get; set; }
    public int Amount { get; set; }
    public int AmountPaid { get; set; }
}