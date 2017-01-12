namespace MedicalibaryREST.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Medicalibary_v1 : DbContext
    {
        public Model_Medicalibary_v1()
            : base("name=Model_Medicalibary_v1")
        {
        }

        public virtual DbSet<dane_modyfikacji> dane_modyfikacji { get; set; }
        public virtual DbSet<lekarz> lekarz { get; set; }
        public virtual DbSet<magazyn> magazyn { get; set; }
        public virtual DbSet<modyfikacja> modyfikacja { get; set; }
        public virtual DbSet<pacjent> pacjent { get; set; }
        public virtual DbSet<parametr> parametr { get; set; }
        public virtual DbSet<przypisanie_parametru> przypisanie_parametru { get; set; }
        public virtual DbSet<wersja> wersja { get; set; }
        public virtual DbSet<wizyta> wizyta { get; set; }
        public virtual DbSet<zasada> zasada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dane_modyfikacji>()
                .Property(e => e.nazwa_danej)
                .IsUnicode(false);

            modelBuilder.Entity<dane_modyfikacji>()
                .Property(e => e.stara_wartosc)
                .IsUnicode(false);

            modelBuilder.Entity<dane_modyfikacji>()
                .Property(e => e.nowa_wartosc)
                .IsUnicode(false);

            modelBuilder.Entity<lekarz>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<lekarz>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.dane_modyfikacji)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.magazyn)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.modyfikacja)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.pacjent)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.parametr)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.przypisanie_parametru)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.wersja)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.wizyta)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<lekarz>()
                .HasMany(e => e.zasada)
                .WithOptional(e => e.lekarz)
                .HasForeignKey(e => e.id_lekarz);

            modelBuilder.Entity<magazyn>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<magazyn>()
                .HasMany(e => e.pacjent)
                .WithOptional(e => e.magazyn)
                .HasForeignKey(e => e.id_magazyn);

            modelBuilder.Entity<magazyn>()
                .HasMany(e => e.zasada)
                .WithOptional(e => e.magazyn)
                .HasForeignKey(e => e.id_magazyn);

            modelBuilder.Entity<modyfikacja>()
                .Property(e => e.obiekt)
                .IsUnicode(false);

            modelBuilder.Entity<modyfikacja>()
                .Property(e => e.operaca)
                .IsUnicode(false);

            modelBuilder.Entity<modyfikacja>()
                .HasMany(e => e.dane_modyfikacji)
                .WithOptional(e => e.modyfikacja)
                .HasForeignKey(e => e.id_modyfikacja);

            modelBuilder.Entity<pacjent>()
                .Property(e => e.imie)
                .IsUnicode(false);

            modelBuilder.Entity<pacjent>()
                .Property(e => e.nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<pacjent>()
                .Property(e => e.pesel)
                .HasPrecision(11, 0);

            modelBuilder.Entity<pacjent>()
                .HasMany(e => e.przypisanie_parametru)
                .WithOptional(e => e.pacjent)
                .HasForeignKey(e => e.id_pacjent);

            modelBuilder.Entity<pacjent>()
                .HasMany(e => e.wizyta)
                .WithOptional(e => e.pacjent)
                .HasForeignKey(e => e.id_pacjent);

            modelBuilder.Entity<parametr>()
                .Property(e => e.typ)
                .IsUnicode(false);

            modelBuilder.Entity<parametr>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<parametr>()
                .Property(e => e.wartosc_domyslna)
                .IsUnicode(false);

            modelBuilder.Entity<parametr>()
                .HasMany(e => e.przypisanie_parametru)
                .WithOptional(e => e.parametr)
                .HasForeignKey(e => e.id_parametr);

            modelBuilder.Entity<przypisanie_parametru>()
                .Property(e => e.wartosc)
                .IsUnicode(false);

            modelBuilder.Entity<wersja>()
                .HasMany(e => e.modyfikacja)
                .WithOptional(e => e.wersja)
                .HasForeignKey(e => e.id_wersji);

            modelBuilder.Entity<wizyta>()
                .Property(e => e.komentarz)
                .IsUnicode(false);

            modelBuilder.Entity<zasada>()
                .Property(e => e.nazwa_atrybutu)
                .IsUnicode(false);

            modelBuilder.Entity<zasada>()
                .Property(e => e.operacja_porownania)
                .IsUnicode(false);

            modelBuilder.Entity<zasada>()
                .Property(e => e.wartosc_porownania)
                .IsUnicode(false);
        }
    }
}
