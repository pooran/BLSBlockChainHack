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
    
    public partial class UsusarioFarmacia
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int FarmaciaId { get; set; }
        public string EstaActivo { get; set; }
    
        public virtual Farmacia Farmacia { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
