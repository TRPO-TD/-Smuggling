//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork4Test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delay_penalty
    {
        public int delp_id { get; set; }
        public int d_id { get; set; }
        public Nullable<double> delp_ammount { get; set; }
        public string delp_description { get; set; }
    
        public virtual Deal Deal { get; set; }
    }
}
