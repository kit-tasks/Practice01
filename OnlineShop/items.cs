//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public items()
        {
            this.sells = new HashSet<sells>();
        }
    
        public int id { get; set; }
        public string category { get; set; }
        public int wholesalePrice { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sells> sells { get; set; }
    }
}
