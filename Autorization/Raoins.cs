//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autorization
{
    using System;
    using System.Collections.Generic;
    
    public partial class Raoins
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Raoins()
        {
            this.address_subscriber = new HashSet<address_subscriber>();
        }
    
        public int id_raion { get; set; }
        public string raion_name { get; set; }
        public string square { get; set; }
        public int population { get; set; }
        public int count_metro { get; set; }
        public int id_type_binding { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address_subscriber> address_subscriber { get; set; }
        public virtual type_binding type_binding { get; set; }
    }
}
