using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sona.Models;

public partial class SonaDbContext : DbContext
{
    public SonaDbContext()
    {
    }

    public SonaDbContext(DbContextOptions<SonaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MR3HIRK;Initial Catalog=Sona_db;Integrated Security=True; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name_Category)
                .HasMaxLength(50)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.DateWrite)
                .HasColumnType("date")
                .HasColumnName("Date_write");
            entity.Property(e => e.ParagraphText1)
                .HasMaxLength(100)
                .HasColumnName("Paragraph_text1");
            entity.Property(e => e.ParagraphText2)
                .HasMaxLength(100)
                .HasColumnName("Paragraph_text2");
            entity.Property(e => e.ParagraphText3)
                .HasMaxLength(100)
                .HasColumnName("Paragraph_text3");
            entity.Property(e => e.ParagraphText4)
                .HasMaxLength(100)
                .HasColumnName("Paragraph_text4");
            entity.Property(e => e.ParagraphText5)
                .HasMaxLength(100)
                .HasColumnName("Paragraph_text5");
            entity.Property(e => e.PhotoPath1)
                .HasMaxLength(100)
                .HasColumnName("Photo_path1");
            entity.Property(e => e.PhotoPath2)
                .HasMaxLength(100)
                .HasColumnName("Photo_path2");
            entity.Property(e => e.PhotoPath3)
                .HasMaxLength(100)
                .HasColumnName("Photo_path3");
            entity.Property(e => e.PhotoPath4)
                .HasMaxLength(100)
                .HasColumnName("Photo_path4");
            entity.Property(e => e.PhotoPath5)
                .HasMaxLength(100)
                .HasColumnName("Photo_path5");
            entity.Property(e => e.Title1)
                .HasMaxLength(50)
                .HasColumnName("Title_1");
            entity.Property(e => e.Title2)
                .HasMaxLength(50)
                .HasColumnName("Title_2");
            entity.Property(e => e.Title3)
                .HasMaxLength(50)
                .HasColumnName("Title_3");
            entity.Property(e => e.Title4)
                .HasMaxLength(50)
                .HasColumnName("Title_4");
            entity.Property(e => e.Writer).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.News)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_News_Category");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountGuest)
                .HasMaxLength(1)
                .HasColumnName("Count_guest");
            entity.Property(e => e.CountRoom)
                .HasMaxLength(1)
                .HasColumnName("Count_room");
            entity.Property(e => e.DateCheckin)
                .HasColumnType("date")
                .HasColumnName("Date_checkin");
            entity.Property(e => e.DateCheckout)
                .HasColumnType("date")
                .HasColumnName("Date_checkout");
            entity.Property(e => e.NameClient)
                .HasMaxLength(50)
                .HasColumnName("Name_client");
            entity.Property(e => e.PhonenumClient)
                .HasMaxLength(16)
                .HasColumnName("Phonenum_client");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BedRoom)
                .HasMaxLength(50)
                .HasColumnName("Bed_room");
            entity.Property(e => e.CapacityRoom).HasColumnName("Capacity_room");
            entity.Property(e => e.DescriptionRoom)
                .HasMaxLength(1000)
                .HasColumnName("Description_room");
            entity.Property(e => e.NameRoom)
                .HasMaxLength(50)
                .HasColumnName("Name_room");
            entity.Property(e => e.PriceRoom)
                .HasMaxLength(6)
                .HasColumnName("Price_room");
            entity.Property(e => e.RateRoom).HasColumnName("Rate_room");
            entity.Property(e => e.SizeRoom).HasColumnName("Size_room");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.NameService)
                .HasMaxLength(50)
                .HasColumnName("Name_service");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.ToTable("Testimonial");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CountStar).HasColumnName("Count_star");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .HasColumnName("Name_user");
            entity.Property(e => e.TextTestimonial)
                .HasMaxLength(300)
                .HasColumnName("Text_testimonial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
