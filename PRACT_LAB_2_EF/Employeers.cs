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
    
    public partial class Employeers
    {
        public int employeer_id { get; set; }
        public string employeer_name { get; set; }
        public string employeer_surname { get; set; }
        public string employeer_middlename { get; set; }
        public int id_post { get; set; }

        public Employeers(string em_name, string em_surname, string em_midlename, int id_post, Posts posts)
        {
            employeer_name = em_name;
            employeer_surname = em_surname;
            employeer_middlename = em_midlename;
            employeer_id = id_post;
            this.Posts = posts;
        }

        public Employeers() { }

        public virtual Posts Posts { private get; set; }
    }
}
