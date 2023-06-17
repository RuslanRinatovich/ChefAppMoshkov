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
    
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.GoodFeedBacks = new HashSet<GoodFeedBack>();
            this.OrderGoods = new HashSet<OrderGood>();
        }
    
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodFeedBack> GoodFeedBacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderGood> OrderGoods { get; set; }
    }
}
