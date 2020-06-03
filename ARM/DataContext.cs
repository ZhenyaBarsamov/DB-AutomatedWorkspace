namespace ARM {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext {
        public DataContext()
            : base("name=DataContext") {
        }

        public virtual DbSet<actor> actors { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<film> films { get; set; }
        public virtual DbSet<films_and_actors> films_and_actors { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<actor>()
                .HasMany(e => e.films_and_actors)
                .WithRequired(e => e.actor)
                .HasForeignKey(e => e.actor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<company>()
                .HasMany(e => e.films)
                .WithOptional(e => e.company)
                .HasForeignKey(e => e.company_id);

            modelBuilder.Entity<film>()
                .Property(e => e.budget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<film>()
                .HasMany(e => e.films_and_actors)
                .WithRequired(e => e.film)
                .HasForeignKey(e => e.film_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<films_and_actors>()
                .Property(e => e.actor_honorarium)
                .HasPrecision(19, 4);
        }
    }
}
