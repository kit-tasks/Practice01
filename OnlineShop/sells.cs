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
    
    public partial class sells
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public int userId { get; set; }
        public int managerId { get; set; }
        public System.DateTime creationDate { get; set; }
        public string buyInfo { get; set; }
        public int status { get; set; }
    
        public virtual items items { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
    }
}