﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MeditEntities : DbContext
    {
        public MeditEntities()
            : base("name=MeditEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Emploi> Emploi { get; set; }
        public virtual DbSet<Entreprise> Entreprise { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }
        public virtual DbSet<ExamenParticulier> ExamenParticulier { get; set; }
        public virtual DbSet<Lan_Exa> Lan_Exa { get; set; }
        public virtual DbSet<Lan_Prof> Lan_Prof { get; set; }
        public virtual DbSet<Lan_Risque> Lan_Risque { get; set; }
        public virtual DbSet<Langue> Langue { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<Ris_Exa> Ris_Exa { get; set; }
        public virtual DbSet<Risque> Risque { get; set; }
        public virtual DbSet<Risque_TravSoumis> Risque_TravSoumis { get; set; }
        public virtual DbSet<Travailleur> Travailleur { get; set; }
    }
}
