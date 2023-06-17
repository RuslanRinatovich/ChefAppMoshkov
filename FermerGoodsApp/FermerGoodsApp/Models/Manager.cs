using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FermerGoodsApp.Models
{

  


    public class Manager
    {
        public static Frame MainFrame { get; set; }
        public static TextBlock TbCount { get; set; }
        public static Badged BadgeCount { get; set; }
        public static Client currentClient { get; set; }

        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }

       
        }
        public class ItemOf
        {
            public Good Good { get; set; }
            public BuyItem BuyItem { get; set; }
        }

        public static Dictionary<Good, BuyItem> buyGoods = new Dictionary<Good, BuyItem>();
    }
}
