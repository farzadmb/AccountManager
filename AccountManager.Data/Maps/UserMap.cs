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
        /// The default constructor
        /// </summary>
        /// <param name="entityBuilder">
        /// The entity builder
        /// </param>
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.ToTable("user");

            entityBuilder.Property(a => a.Id).HasColumnName("id");
            entityBuilder.Property(a => a.Name).IsRequired().HasColumnName("name");
            entityBuilder.Property(a => a.Email).IsRequired().HasColumnName("email");
            entityBuilder.Property(a => a.Salary).HasColumnName("salary");
            entityBuilder.Property(a => a.Expenses).HasColumnName("expenses");
        }

        #endregion
    }
}