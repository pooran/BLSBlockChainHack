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
    
    public partial class Clinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clinica()
        {
            this.Pacientes = new HashSet<Paciente>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaDeCreacion1 { get; set; }
        public Nullable<System.DateTime> FechaModificada1 { get; set; }
        public bool EstaActivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
