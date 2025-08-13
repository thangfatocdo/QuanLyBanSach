using WebBanSach.Model;
namespace WebBanSach.Models.ViewModels
{
    public class CartViewModel
    {
        public Book book { get; set; }
        public int amount { get; set; }
        public decimal TotalMoney => amount * book.Price;
    }
}
