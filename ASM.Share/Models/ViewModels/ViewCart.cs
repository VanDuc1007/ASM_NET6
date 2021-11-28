using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM.Share.Models
{
    public class Cart
    {
        public int KhachhangId { get; set; }
        public List<CartItem> ListViewCart { get; set; } = new List<CartItem>();
        public double Tongtien { get; set; }
    }

    public class CartItem
    {
        public MonAn MonAn { get; set; }
        public int Quantity { get; set; }
        public double Sotien { get; set; }
    }

    public class ViewCart
    {
        public MonAn MonAn { get; set; }
        public int Quantity { get; set; }
    }
}
