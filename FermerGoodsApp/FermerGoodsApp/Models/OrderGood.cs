//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FermerGoodsApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderGood
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public int Count { get; set; }
    
        public virtual Good Good { get; set; }
        public virtual Order Order { get; set; }
    }
}
