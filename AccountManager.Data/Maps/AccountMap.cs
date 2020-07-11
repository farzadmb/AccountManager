using AccountManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManager.Data.Maps
{
    /// <summary>
    /// The mapper for <see cref="Account"/>
    /// </summary>
    public class AccountMap
    {
        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="entityBuilder">
        /// The entity builder
        /// </param>
        public AccountMap(EntityTypeBuilder<Account> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);
            entityBuilder.ToTable("account");

            entityBuilder.Property(a => a.Id).HasColumnName("id");
            entityBuilder.Property(a => a.CreationDate).HasColumnName("date");
            entityBuilder.Property(a => a.IsActive).HasColumnName("isActive");

            entityBuilder.HasOne(a => a.User).WithMany(u => u.Accounts).HasForeignKey(a => a.Id);
        }

        #endregion
    }
}