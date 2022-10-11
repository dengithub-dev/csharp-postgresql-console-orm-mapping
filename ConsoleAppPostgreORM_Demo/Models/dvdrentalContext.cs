using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleAppPostgreORM_Demo.Models
{
    public partial class dvdrentalContext : DbContext
    {
        public dvdrentalContext()
        {
        }

        public dvdrentalContext(DbContextOptions<dvdrentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=dvdrental;User Id=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("mpaa_rating", new[] { "G", "PG", "PG-13", "R", "NC-17" });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.HasIndex(e => e.Fulltext, "film_fulltext_idx")
                    .HasMethod("gist");

                entity.HasIndex(e => e.LanguageId, "idx_fk_language_id");

                entity.HasIndex(e => e.Title, "idx_title");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Fulltext).HasColumnName("fulltext");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");

                entity.Property(e => e.RentalDuration)
                    .HasColumnName("rental_duration")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.RentalRate)
                    .HasPrecision(4, 2)
                    .HasColumnName("rental_rate")
                    .HasDefaultValueSql("4.99");

                entity.Property(e => e.ReplacementCost)
                    .HasPrecision(5, 2)
                    .HasColumnName("replacement_cost")
                    .HasDefaultValueSql("19.99");

                entity.Property(e => e.SpecialFeatures).HasColumnName("special_features");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.HasSequence("actor_actor_id_seq");

            modelBuilder.HasSequence("address_address_id_seq");

            modelBuilder.HasSequence("category_category_id_seq");

            modelBuilder.HasSequence("city_city_id_seq");

            modelBuilder.HasSequence("country_country_id_seq");

            modelBuilder.HasSequence("customer_customer_id_seq");

            modelBuilder.HasSequence("film_film_id_seq");

            modelBuilder.HasSequence("inventory_inventory_id_seq");

            modelBuilder.HasSequence("language_language_id_seq");

            modelBuilder.HasSequence("payment_payment_id_seq");

            modelBuilder.HasSequence("rental_rental_id_seq");

            modelBuilder.HasSequence("staff_staff_id_seq");

            modelBuilder.HasSequence("store_store_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
