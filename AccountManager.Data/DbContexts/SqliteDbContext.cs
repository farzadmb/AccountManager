using AccountManager.Data.Maps;
using AccountManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Data.DbContexts
{
    /// <summary>
    /// DbContext working with SqLite
    /// </summary>
    public class SqliteDbContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets the users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the accounts
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        #endregion

        #region Constructor

        public SqliteDbContext()
        {
            Database.EnsureCreated();
        }

        #endregion

        #region Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=AccountManager.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
             
            new UserMap(modelBuilder.Entity<User>());
            new AccountMap(modelBuilder.Entity<Account>());
        }

        #endregion
    }
}