//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSOServer.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERINFO()
        {
            this.USER_DEPARTMENT = new HashSet<USER_DEPARTMENT>();
            this.ROLEINFO = new HashSet<ROLEINFO>();
        }
    
        public decimal USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAYNAME { get; set; }
        public string SHORTNAME { get; set; }
        public Nullable<decimal> USERTYPEID { get; set; }
        public string CREATETIME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<bool> ISLOCKEDOUT { get; set; }
        public string EMAIL { get; set; }
        public string NICKNAME { get; set; }
        public string UPDATETIME { get; set; }
        public Nullable<decimal> WEIGHT { get; set; }
        public string USERIMAGES { get; set; }
        public Nullable<decimal> SINDEX { get; set; }
        public string EXTRAID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_DEPARTMENT> USER_DEPARTMENT { get; set; }
        public virtual USERTYPE USERTYPE { get; set; }
        public virtual USERLEVEL USERLEVEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLEINFO> ROLEINFO { get; set; }
    }
}
