using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermerGoodsApp.Models
{
    public partial class ChefBDEntities : DbContext
    {
        private static ChefBDEntities _context;


        public static ChefBDEntities GetContext()
        {
            if (_context == null)
            {
                _context = new ChefBDEntities();
            }
            return _context;
        }
    }
}
