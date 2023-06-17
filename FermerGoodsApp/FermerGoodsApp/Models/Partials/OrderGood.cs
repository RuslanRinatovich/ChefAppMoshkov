using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermerGoodsApp.Models
{
    public partial class OrderGood
    {
        public double Price
        {

            get
            {
                return Count * Good.Price;
            }
        }
    }
}
