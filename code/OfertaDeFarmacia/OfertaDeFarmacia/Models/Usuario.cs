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
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Pacientes = new HashSet<Paciente>();
            this.UsuarioTrabajoes = new HashSet<UsuarioTrabajo>();
            this.UsusarioFarmacias = new HashSet<UsusarioFarmacia>();
        }
    
        public int Id { get; set; }
        public string RUT { get; set; }
        public string Clave { get; set; }
        public System.DateTime FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificada { get; set; }
        public bool EstaActivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Pacientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioTrabajo> UsuarioTrabajoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsusarioFarmacia> UsusarioFarmacias { get; set; }
    }
}