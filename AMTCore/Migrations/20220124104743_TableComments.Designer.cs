﻿// <auto-generated />
using System;
using AMTCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AMTCore.Migrations
{
    [DbContext(typeof(AMTContext))]
    [Migration("20220124104743_TableComments")]
    partial class TableComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AMTCore.Models.Besuch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grund")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KontaktpersonId")
                        .HasColumnType("int");

                    b.Property<int?>("LernenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontaktpersonId");

                    b.HasIndex("LernenderId");

                    b.ToTable("Besuche");

                    b.HasComment("Besuche");
                });

            modelBuilder.Entity("AMTCore.Models.Kontaktperson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LehrfirmaId")
                        .HasColumnType("int");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LehrfirmaId");

                    b.ToTable("Kontaktpersonen");

                    b.HasComment("Tabelle der Kontaktpersonen");
                });

            modelBuilder.Entity("AMTCore.Models.Lehrfirma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plz")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lehrfirmen");

                    b.HasComment("Tabelle der Lehrfirmen mit Adresse");
                });

            modelBuilder.Entity("AMTCore.Models.Lernende", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BMS")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BeginnGrundausbildung")
                        .HasColumnType("datetime2");

                    b.Property<string>("Beruf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndeGrundausbildung")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Geburtsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Geschlecht")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Klassenjahrgang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LehrfirmaId")
                        .HasColumnType("int");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Schule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schulklasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LehrfirmaId");

                    b.ToTable("Lernende");

                    b.HasComment("Tabelle Lernende");
                });

            modelBuilder.Entity("AMTCore.Models.LernendeKontaktperson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("KontaktpersonId")
                        .HasColumnType("int");

                    b.Property<int?>("LernendeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontaktpersonId");

                    b.HasIndex("LernendeId");

                    b.ToTable("LernendeKontaktpersonen");
                });

            modelBuilder.Entity("AMTCore.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Gewicht")
                        .HasColumnType("real");

                    b.Property<bool>("IstMP")
                        .HasColumnType("bit");

                    b.Property<int?>("LernenderId")
                        .HasColumnType("int");

                    b.Property<int>("Modul")
                        .HasColumnType("int");

                    b.Property<float>("Wert")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LernenderId");

                    b.ToTable("Noten");

                    b.HasComment("Tabelle in der die Noten der Lernenden abgespeichert sind");
                });

            modelBuilder.Entity("AMTCore.Models.Besuch", b =>
                {
                    b.HasOne("AMTCore.Models.Kontaktperson", "Kontaktperson")
                        .WithMany()
                        .HasForeignKey("KontaktpersonId");

                    b.HasOne("AMTCore.Models.Lernende", "Lernender")
                        .WithMany()
                        .HasForeignKey("LernenderId");

                    b.Navigation("Kontaktperson");

                    b.Navigation("Lernender");
                });

            modelBuilder.Entity("AMTCore.Models.Kontaktperson", b =>
                {
                    b.HasOne("AMTCore.Models.Lehrfirma", "Lehrfirma")
                        .WithMany()
                        .HasForeignKey("LehrfirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lehrfirma");
                });

            modelBuilder.Entity("AMTCore.Models.Lernende", b =>
                {
                    b.HasOne("AMTCore.Models.Lehrfirma", "Lehrfirma")
                        .WithMany()
                        .HasForeignKey("LehrfirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lehrfirma");
                });

            modelBuilder.Entity("AMTCore.Models.LernendeKontaktperson", b =>
                {
                    b.HasOne("AMTCore.Models.Kontaktperson", "Kontaktperson")
                        .WithMany()
                        .HasForeignKey("KontaktpersonId");

                    b.HasOne("AMTCore.Models.Lernende", "Lernende")
                        .WithMany()
                        .HasForeignKey("LernendeId");

                    b.Navigation("Kontaktperson");

                    b.Navigation("Lernende");
                });

            modelBuilder.Entity("AMTCore.Models.Note", b =>
                {
                    b.HasOne("AMTCore.Models.Lernende", "Lernender")
                        .WithMany()
                        .HasForeignKey("LernenderId");

                    b.Navigation("Lernender");
                });
#pragma warning restore 612, 618
        }
    }
}
