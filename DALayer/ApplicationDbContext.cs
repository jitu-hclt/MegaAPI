using System;
using BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace DALayer;

public class ApplicationDbContext:DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext)
		:base(dbContext)
	{
        
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);

        
    }


    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

    
}


