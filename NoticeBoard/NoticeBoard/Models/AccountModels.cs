using NoticeBoard.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace NoticeBoard.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<NoticeEntity> Notices { get; set; }
        public DbSet<NoticePlaceEntity> NoticePlaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<NoticeEntity>()
                .HasRequired<UserProfileEntity>(x => x.UserProfile)
                .WithMany(x => x.Notices)
                .HasForeignKey(x => x.UserProfileId);

            modelBuilder.Entity<NoticeEntity>()
                .HasRequired<NoticePlaceEntity>(x => x.NoticePlace)
                .WithMany(x => x.Notices)
                .HasForeignKey(x => x.NoticePlaceId);

            modelBuilder.Entity<NoticeEntity>()
                .HasRequired<CategoryEntity>(x => x.Category)
                .WithMany(x => x.Notices)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CategoryEntity>()
                .HasOptional<CategoryEntity>(x => x.ParentCategory)
                .WithMany(x => x.CategoryItem)
                .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<AddressEntity>()
                .HasRequired<UserProfileEntity>(x => x.UserProfile)
                .WithOptional(x => x.Address);

        }
    }

    [Table("UserProfile")]
    public class UserProfileEntity
    {
        public UserProfileEntity()
        {
            Notices = new List<NoticeEntity>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<NoticeEntity> Notices { get; set; }
        public virtual AddressEntity Address { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
