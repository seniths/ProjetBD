//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamenParticulier
    {
        public int idExamenParticulier { get; set; }
        public int idExamen { get; set; }
        public int idEmploi { get; set; }
    
        public virtual Emploi Emploi { get; set; }
        public virtual Examen Examen { get; set; }
    }
}
