using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermerGoodsApp.Models
{
    public partial class Good
    {
        public string GetPhoto
        {
            get
            {
                if (Photo is null)
                    return null;
                return System.IO.Directory.GetCurrentDirectory() + @"\Images\" + Photo.Trim();
            }
        }
       
        /// <summary>
        /// Текстовое представление активности товара
        /// </summary>
       

        public string GetVisibilityBuy
        {
            get
            {
                if  ((Manager.currentClient != null) && (Manager.currentClient.RoleId != 2) )
                    return "Visible";
                else
                    return "Collapsed";
            }
        }

        public string GetVisibilityEdit
        {
            get
            {
                if ((Manager.currentClient != null) && (Manager.currentClient.RoleId == 2))
                    return "Visible";
                else
                    return "Collapsed";
            }
        }

        public double Rate
        {
            get
            {
                double rate = 0;
                foreach (GoodFeedBack x in GoodFeedBacks)
                {
                    rate += Convert.ToDouble(x.Rate);
                }
                rate /= GoodFeedBacks.Count;
                return rate;
            }
        }
    }
}
