//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnaOkuluYönetimi
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_AYARLAR
    {
        public int AYARLARID { get; set; }
        public string OGRTSIFRE { get; set; }
    
        public virtual TBL_OGRETMENLER TBL_OGRETMENLER { get; set; }
    }
}
