using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<User>().HasData(
                new List<User>()
                    {
                        new User()
                            {
                                Id = 1,
                                Name = "Fred",
                                Email = "fred@zip.co",
                                Salary = 2000,
                                Expenses = 900
                            },
                        new User()
                            {
                                Id = 2,
                                Name = "John",
                                Email = "john@zip.co",
                                Salary = 2500,
                                Expenses = 1600
                            }
                    });

            modelBuilder.Entity<Account>().HasData(
                new List<Account>() { new Account() { Id = 1, CreationDate = DateTime.Now, UserId = 1, IsActive = true } });
        }

        #endregion
    }
}