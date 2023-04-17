using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Interface;

public partial class DbBarContext : DbContext
{
    public DbBarContext()
    {
    }

    public DbBarContext(DbContextOptions<DbBarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<DrinkIngridient> DrinkIngridients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodIngridient> FoodIngridients { get; set; }

    public virtual DbSet<FullEmploeesPost> FullEmploeesPosts { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Prevjob> Prevjobs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<ProviderProduct> ProviderProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R8KJVR7\\SQLEXPRESS;Initial Catalog=DB_BAR;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.HasKey(e => e.BankId).HasName("PK__BankDeta__AA08CB138D88E16F");

            entity.Property(e => e.CheckingAccount).HasMaxLength(30);
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasDefaultValueSql("('Polotsk')");

            entity.HasOne(d => d.Provider).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__BankDetai__Provi__59FA5E80");
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.DrinkId).HasName("PK__Drinks__C094D3E845A45EB6");

            entity.Property(e => e.Capasity)
                .HasMaxLength(1)
                .HasDefaultValueSql("('Cup')");
            entity.Property(e => e.DrinkName)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Cup of voter')");
        });

        modelBuilder.Entity<DrinkIngridient>(entity =>
        {
            entity.HasKey(e => e.DrinkIngridientId).HasName("PK__DrinkIng__5E0A2C1973AF4E41");

            entity.ToTable("DrinkIngridient");

            entity.HasOne(d => d.Drink).WithMany(p => p.DrinkIngridients)
                .HasForeignKey(d => d.DrinkId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DrinkIngr__Drink__41EDCAC5");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.DrinkIngridients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__DrinkIngr__Ingre__42E1EEFE");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07C42AB9D0");

            entity.Property(e => e.DateOfBirth)
                .HasDefaultValueSql("('2000-01-01')")
                .HasColumnType("date");
            entity.Property(e => e.EmployeeAddress).HasMaxLength(40);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasDefaultValueSql("('NIKITA')");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(20)
                .HasDefaultValueSql("('--')");
            entity.Property(e => e.Salary)
                .HasDefaultValueSql("((500))")
                .HasColumnType("smallmoney");
            entity.Property(e => e.SecondName)
                .HasMaxLength(20)
                .HasDefaultValueSql("('--')");

            entity.HasOne(d => d.EmployeePost).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePostId)
                .HasConstraintName("FK__Employees__Emplo__398D8EEE");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Food__856DB3EBBFD150CA");

            entity.ToTable("Food");

            entity.Property(e => e.FoodName).HasMaxLength(20);
        });

        modelBuilder.Entity<FoodIngridient>(entity =>
        {
            entity.HasKey(e => e.FoodIngridientId).HasName("PK__FoodIngr__72424ADCA583D7BD");

            entity.ToTable("FoodIngridient");

            entity.HasOne(d => d.Drink).WithMany(p => p.FoodIngridients)
                .HasForeignKey(d => d.DrinkId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FoodIngri__Drink__45BE5BA9");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.FoodIngridients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__FoodIngri__Ingre__46B27FE2");
        });

        modelBuilder.Entity<FullEmploeesPost>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FullEmploeesPosts");

            entity.Property(e => e.EmployeeAddress).HasMaxLength(40);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Patronymic).HasMaxLength(20);
            entity.Property(e => e.PostName).HasMaxLength(30);
            entity.Property(e => e.Salary).HasColumnType("smallmoney");
            entity.Property(e => e.SecondName).HasMaxLength(20);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB25A35A1263A");

            entity.Property(e => e.IngredientCount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Product).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Ingredien__Produ__3E1D39E1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__AA126018E2585201");

            entity.Property(e => e.PostName).HasMaxLength(30);
        });

        modelBuilder.Entity<Prevjob>(entity =>
        {
            entity.HasKey(e => e.PrevJobId).HasName("PK__Prevjob__E59D95C0A9682AE8");

            entity.ToTable("Prevjob");

            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.Employees).WithMany(p => p.Prevjobs)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Prevjob__Employe__412EB0B6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD17BB20C8");

            entity.Property(e => e.ProductName).HasMaxLength(20);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__B54C687DA513419D");

            entity.Property(e => e.Adress).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(1);
            entity.Property(e => e.ProvideName).HasMaxLength(30);
        });

        modelBuilder.Entity<ProviderProduct>(entity =>
        {
            entity.HasKey(e => e.ProviderProductsId).HasName("PK__Provider__5D9B70F4FACA2618");

            entity.HasOne(d => d.Product).WithMany(p => p.ProviderProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProviderP__Produ__4D5F7D71");

            entity.HasOne(d => d.Provider).WithMany(p => p.ProviderProducts)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProviderP__Provi__4C6B5938");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C8E2E0E40");

            entity.Property(e => e.UserLogin).HasMaxLength(8000);
            entity.Property(e => e.UserName).HasMaxLength(20);
            entity.Property(e => e.UserPassword).HasMaxLength(8000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
