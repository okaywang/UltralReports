//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.AccountAuthorities = new HashSet<AccountAuthority>();
        }
    
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Common.Types.AccountType AccountType { get; set; }
        public Nullable<System.DateTime> FADateTime { get; set; }
        public string FAUser { get; set; }
        public Nullable<System.DateTime> LCDateTime { get; set; }
        public string LCUser { get; set; }
    
        public virtual ICollection<AccountAuthority> AccountAuthorities { get; set; }
    }
}
