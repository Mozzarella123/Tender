﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using TenderApp.Data;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180107214155_FixMobelMaybe")]
    partial class FixMobelMaybe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TenderApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int?>("PostId");

                    b.HasKey("AttachmentId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.Property<string>("Type");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Post");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Post_Meta", b =>
                {
                    b.Property<int>("Post_MetaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int?>("ParentPost_MetaId");

                    b.Property<int?>("PostId");

                    b.Property<string>("Value");

                    b.HasKey("Post_MetaId");

                    b.HasIndex("ParentPost_MetaId");

                    b.HasIndex("PostId");

                    b.ToTable("Post_Meta");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Sub", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<int?>("SubGroupId");

                    b.Property<int>("Type");

                    b.HasKey("SubId");

                    b.HasIndex("SubGroupId");

                    b.ToTable("Subs");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.SubGroup", b =>
                {
                    b.Property<int>("SubGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ForType");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.HasKey("SubGroupId");

                    b.ToTable("SabGroups");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.User_Meta", b =>
                {
                    b.Property<int>("User_MetaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int?>("ParentUser_MetaId");

                    b.Property<string>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("User_MetaId");

                    b.HasIndex("ParentUser_MetaId");

                    b.HasIndex("UserId");

                    b.ToTable("User_Meta");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Comment", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Post");

                    b.Property<int?>("PostId1");

                    b.HasIndex("PostId1");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Comment");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Offer", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Post");

                    b.Property<int?>("OrganizationPostId")
                        .HasColumnName("Offer_OrganizationPostId");

                    b.Property<double>("Price");

                    b.HasIndex("OrganizationPostId");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Offer");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Organization", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Post");

                    b.Property<string>("Adress");

                    b.ToTable("Organization");

                    b.HasDiscriminator().HasValue("Organization");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Tender", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Post");

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("OrganizationPostId")
                        .HasColumnName("Tender_OrganizationPostId");

                    b.Property<DateTime>("StartTime");

                    b.HasIndex("OrganizationPostId");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Tender");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Application", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Comment");

                    b.Property<int?>("OrganizationPostId");

                    b.Property<int?>("TenderPostId");

                    b.HasIndex("OrganizationPostId");

                    b.HasIndex("TenderPostId");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Application");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Review", b =>
                {
                    b.HasBaseType("TenderApp.Models.BusinessModels.Comment");

                    b.Property<int>("Mark");

                    b.Property<int?>("OrganizationPostId")
                        .HasColumnName("Review_OrganizationPostId");

                    b.HasIndex("OrganizationPostId");

                    b.ToTable("Posts");

                    b.HasDiscriminator().HasValue("Review");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TenderApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TenderApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TenderApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Attachment", b =>
                {
                    b.HasOne("TenderApp.Models.ApplicationUser")
                        .WithMany("Attachments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TenderApp.Models.BusinessModels.Post")
                        .WithMany("Attachments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Category", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Post", b =>
                {
                    b.HasOne("TenderApp.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Post_Meta", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Post_Meta", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentPost_MetaId");

                    b.HasOne("TenderApp.Models.BusinessModels.Post")
                        .WithMany("Metas")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Sub", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.SubGroup")
                        .WithMany("Subs")
                        .HasForeignKey("SubGroupId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.User_Meta", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.User_Meta", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentUser_MetaId");

                    b.HasOne("TenderApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Comment", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId1");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Offer", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Organization", "Organization")
                        .WithMany("Offers")
                        .HasForeignKey("OrganizationPostId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Tender", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationPostId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Application", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Organization")
                        .WithMany("Applications")
                        .HasForeignKey("OrganizationPostId");

                    b.HasOne("TenderApp.Models.BusinessModels.Tender")
                        .WithMany("Offers")
                        .HasForeignKey("TenderPostId");
                });

            modelBuilder.Entity("TenderApp.Models.BusinessModels.Review", b =>
                {
                    b.HasOne("TenderApp.Models.BusinessModels.Organization")
                        .WithMany("Reviews")
                        .HasForeignKey("OrganizationPostId");
                });
#pragma warning restore 612, 618
        }
    }
}
