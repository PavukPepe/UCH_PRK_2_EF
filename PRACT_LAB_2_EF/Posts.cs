//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRACT_LAB_2_EF
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Annotations;

    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            this.Employeers = new HashSet<Employeers>();
        }
    
        public int post_id { get; set; }
        public string post_name { get; set; }
        public float post_salary { get; set; }

        public Posts(string post_name, float post_salary)
        {
            this.post_name = post_name;
            this.post_salary = post_salary;
            this.Employeers = new HashSet<Employeers>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employeers> Employeers { private get; set; }
    }
}
