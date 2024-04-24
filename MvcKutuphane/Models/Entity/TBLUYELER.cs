//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLUYELER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUYELER()
        {
            this.TBLCEZALAR = new HashSet<TBLCEZALAR>();
            this.TBLHAREKET = new HashSet<TBLHAREKET>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage ="Ad� Bo� B�rakamazs�n�z ")]
        [StringLength(20,ErrorMessage ="En Fazla 20 Karekter Girebilirsiniz")]
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string MAIL { get; set; }
        public string KULLANICIADI { get; set; }
        [Required(ErrorMessage = "�ifre Bo� B�rakamazs�n�z ")]
        [StringLength(10, ErrorMessage = "En Fazla 10 Karekter Girebilirsiniz")]

        public string SIFRE { get; set; }
        public string FOTOGRAF { get; set; }
        public string TELEFON { get; set; }
        public string OKUL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCEZALAR> TBLCEZALAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
    }
}
