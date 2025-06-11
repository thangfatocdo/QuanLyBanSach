namespace Doan1.Models;

public class Bill
{
    public string BillId { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
    public string CustomerName { get; set; }
    public string StatusName { get; set; }
}
public class MobileOrder
{
    public int OrderId { get; set; }     // hoặc string nếu là chuỗi
    public string Title { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime? OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string StatusName { get; set; }
}