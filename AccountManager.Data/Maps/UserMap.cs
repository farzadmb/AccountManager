using AccountManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Data.Maps
{
    /// <summary>
    /// The mapper for <see cref="User"/>
    /// </summary>
    public class UserMap
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMap"/> class.
        /// </summary>
        /// <param name="entityBuilder">
        /// The entity builder
        /// </param>
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.HasIndex(u => u.Email).IsUnique();

            entityBuilder.ToTable("user");
            entityBuilder.Property(u => u.Id).HasColumnName("id");
            entityBuilder.Property(u => u.Name).IsRequired().HasColumnName("name");
            entityBuilder.Property(u => u.Email).IsRequired().HasColumnName("email");
            entityBuilder.Property(u => u.Salary).HasColumnName("salary");
            entityBuilder.Property(u => u.Expenses).HasColumnName("expenses");

            entityBuilder.HasMany(u => u.Accounts).WithOne(a => a.User);
        }

        #endregion
    }
}