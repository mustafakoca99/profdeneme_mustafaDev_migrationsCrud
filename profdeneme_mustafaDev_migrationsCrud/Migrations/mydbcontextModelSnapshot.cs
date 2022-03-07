﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using profdeneme_mustafaDev_migrationsCrud.Models;

#nullable disable

namespace profdeneme_mustafaDev_migrationsCrud.Migrations
{
    [DbContext(typeof(mydbcontext))]
    partial class mydbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("profdeneme_mustafaDev_migrationsCrud.Models.kitap", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("kitapadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kitapsayfasi")
                        .HasColumnType("int");

                    b.Property<string>("kitapturu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("kitap");
                });

            modelBuilder.Entity("profdeneme_mustafaDev_migrationsCrud.Models.kitaptoyazar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("kitapf_id")
                        .HasColumnType("int");

                    b.Property<int>("yazarf_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("kitapf_id");

                    b.HasIndex("yazarf_id");

                    b.ToTable("kitaptoyazar");
                });

            modelBuilder.Entity("profdeneme_mustafaDev_migrationsCrud.Models.yazar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("yazaradi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yazaryasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("yazar");
                });

            modelBuilder.Entity("profdeneme_mustafaDev_migrationsCrud.Models.kitaptoyazar", b =>
                {
                    b.HasOne("profdeneme_mustafaDev_migrationsCrud.Models.kitap", "kitaplar")
                        .WithMany()
                        .HasForeignKey("kitapf_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("profdeneme_mustafaDev_migrationsCrud.Models.yazar", "yazarlar")
                        .WithMany()
                        .HasForeignKey("yazarf_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kitaplar");

                    b.Navigation("yazarlar");
                });
#pragma warning restore 612, 618
        }
    }
}
