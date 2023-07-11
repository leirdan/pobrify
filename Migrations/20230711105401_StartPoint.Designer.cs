using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using pobrify;

namespace pobrify.Migrations
{
    [DbContext(typeof(PobrifyContext))]
    [Migration("20230711105401_StartPoint")]
    partial class StartPoint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("pobrify.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("pobrify.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Length");

                    b.Property<string>("Owner");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("pobrify.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<string>("Length");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });
        }
    }
}
