//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class auto
    {
        
        public auto()
        {
            this.order = new HashSet<order>();
        }
    
        public int idauto { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public Nullable<int> horsePower { get; set; }
        public Nullable<int> year { get; set; }
        public string transmission { get; set; }
    
        public virtual ICollection<order> order { get; set; }
    }
}
