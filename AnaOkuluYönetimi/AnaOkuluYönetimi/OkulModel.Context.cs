﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbOkulEntities : DbContext
    {
        public DbOkulEntities()
            : base("name=DbOkulEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBL_BRANSLAR> TBL_BRANSLAR { get; set; }
        public virtual DbSet<TBL_ILCELER> TBL_ILCELER { get; set; }
        public virtual DbSet<TBL_ILLER> TBL_ILLER { get; set; }
        public virtual DbSet<TBL_OGRENCILER> TBL_OGRENCILER { get; set; }
        public virtual DbSet<TBL_OGRETMENLER> TBL_OGRETMENLER { get; set; }
        public virtual DbSet<TBL_VELILER> TBL_VELILER { get; set; }
        public virtual DbSet<TBL_AYARLAR> TBL_AYARLAR { get; set; }
        public virtual DbSet<TBL_OGRAYARLAR> TBL_OGRAYARLAR { get; set; }
    
        public virtual ObjectResult<AyarlarOgrencıler_Result> AyarlarOgrencıler()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AyarlarOgrencıler_Result>("AyarlarOgrencıler");
        }
    
        public virtual ObjectResult<AyarlarOgretmenler_Result> AyarlarOgretmenler()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AyarlarOgretmenler_Result>("AyarlarOgretmenler");
        }
    }
}
