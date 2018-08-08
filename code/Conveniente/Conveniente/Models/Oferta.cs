//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conveniente.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oferta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oferta()
        {
            this.NombreMedicinas = new HashSet<NombreMedicina>();
        }
    
        public int Id { get; set; }
        public int FarmaciaId { get; set; }
        public int UsusarioId { get; set; }
        public int PrescripcionId { get; set; }
        public string EstaActivo { get; set; }
        public long Total { get; set; }
        public Nullable<int> SeguroId { get; set; }
        public bool EsAceptado { get; set; }
        public bool EsRecogido { get; set; }
        public string Code { get; set; }
    
        public virtual Farmacia Farmacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NombreMedicina> NombreMedicinas { get; set; }
        public virtual Prescripcion Prescripcion { get; set; }
        public virtual Seguro Seguro { get; set; }
    }
}