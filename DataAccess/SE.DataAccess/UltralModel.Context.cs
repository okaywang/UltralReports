﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UltralReportsEntities : DbContext
    {
        public UltralReportsEntities()
            : base("name=UltralReportsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAuthority> AccountAuthorities { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<LogException> LogExceptions { get; set; }
        public DbSet<LogOperation> LogOperations { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<MonitorType> MonitorType { get; set; }
        public DbSet<Part> Part { get; set; }
        public DbSet<UltraRecord> UltraRecord { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<PartSms> PartSms1 { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<DutyTime> DutyTimes { get; set; }
        public DbSet<SmsGroup> SmsGroups { get; set; }
        public DbSet<SmsGroupAccount> SmsGroupAccounts { get; set; }
    }
}
