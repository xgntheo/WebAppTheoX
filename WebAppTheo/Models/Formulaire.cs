//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppTheo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Formulaire
    {
        public int IdForm { get; set; }
        public int IdEquipm { get; set; }
        public string TypeMaintenance { get; set; }
        public string ReparationDiverse { get; set; }
        public int IdClient { get; set; }
        public int IdTech { get; set; }
        public Nullable<int> TempsMinute { get; set; }
        public Nullable<System.DateTime> DateAjout { get; set; }
        public Nullable<int> Prix { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Equipement Equipement { get; set; }
        public virtual Technicien Technicien { get; set; }
    }
}
