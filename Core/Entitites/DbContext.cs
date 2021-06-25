using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entitites
{
    public partial class HrDemoDbContext : DbContext
    {
        public HrDemoDbContext()
        {
        }

        public HrDemoDbContext(DbContextOptions<HrDemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allowance> Allowance { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=HR_DEMO;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.Property(e => e.EMP_ID).HasColumnName("EMP_ID");
                entity.HasKey(e => e.SEQ_ID);
                
                entity.Property(e => e.ALLOWANCE_ID).HasColumnName("ALLOWANCE_ID");

                entity.HasOne(d => d.Allowance)
                    .WithMany(p => p.EmployeeSalary)
                    .HasForeignKey(d => d.ALLOWANCE_ID)
                    .HasConstraintName("FK_EMPLOYEE_SALARY_ALLOWANCE");
                entity.HasOne(d => d.Employee)
                   .WithMany(p => p.EmployeeSalary)
                   .HasForeignKey(d => d.EMP_ID)
                   .HasConstraintName("FK_EMPLOYEE_SALARY_EMPLOYEE");
                entity.ToTable("Employee_Salary");
            });
            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.HasKey(e => e.SEQID);    
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.SEQ_ID);
            });
            
        }
           
    }
}
