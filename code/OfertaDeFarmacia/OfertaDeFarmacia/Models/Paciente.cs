//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfertaDeFarmacia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.Prescripcions = new HashSet<Prescripcion>();
        }
    
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ClinicId { get; set; }
        public string PacienteId { get; set; }
        public string Clave { get; set; }
        public System.DateTime FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificada { get; set; }
        public bool EstaActivo { get; set; }
    
        public virtual Clinica Clinica { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescripcion> Prescripcions { get; set; }
    }
}