using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AbsentManagement.Models
{
    public partial class DbConnection : DbContext
    {
        public DbConnection()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DayOff> DayOffs { get; set; }
        public virtual DbSet<information> information { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.account_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DayOff>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .Property(e => e.avartar_url)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.subject_name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.DayOffs)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.person_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.information)
                .WithRequired(e => e.Person);
        }
    }
}
