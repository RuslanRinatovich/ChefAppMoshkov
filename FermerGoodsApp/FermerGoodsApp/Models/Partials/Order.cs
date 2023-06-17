using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermerGoodsApp.Models
{
    public partial class Order
    {
        public string Color
        {
            get
            {
                if (Status != null)
                    return Status.Color;

                return "#FFF";

            }

        }

        public string StatusName
        {
            get
            {
               if (Status != null)
                     return Status.Name;
                return "Создан";

            }

        }
    }
}
