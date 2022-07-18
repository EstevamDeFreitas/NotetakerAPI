﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(NotetakerContext))]
    partial class NotetakerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("ntr_description");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<int>("Style")
                        .HasColumnType("integer")
                        .HasColumnName("ntr_style");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ntr_title");

                    b.HasKey("Id");

                    b.ToTable("ntr_notes");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("ntr_description");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<int>("Style")
                        .HasColumnType("integer")
                        .HasColumnName("ntr_style");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ntr_title");

                    b.HasKey("Id");

                    b.ToTable("ntr_projects");
                });

            modelBuilder.Entity("Domain.Entities.ProjectNotes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_note_id");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_project_id");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ntr_project_notes");
                });

            modelBuilder.Entity("Domain.Entities.ProjectUsers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("integer")
                        .HasColumnName("ntr_access_level");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_project_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ntr_project_users");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ntr_email");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ntr_password");

                    b.HasKey("Id");

                    b.ToTable("ntr_users");
                });

            modelBuilder.Entity("Domain.Entities.UserNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_id");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("integer")
                        .HasColumnName("ntr_access_level");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_creation");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ntr_dt_modified");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_note_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("ntr_user_id");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("ntr_user_notes");
                });

            modelBuilder.Entity("Domain.Entities.ProjectNotes", b =>
                {
                    b.HasOne("Domain.Entities.Note", "Note")
                        .WithMany("ProjectNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("ProjectNotes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.ProjectUsers", b =>
                {
                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserNote", b =>
                {
                    b.HasOne("Domain.Entities.Note", "Note")
                        .WithMany("UserNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Note", b =>
                {
                    b.Navigation("ProjectNotes");

                    b.Navigation("UserNotes");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectNotes");

                    b.Navigation("ProjectUsers");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("ProjectUsers");

                    b.Navigation("UserNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
