using Microsoft.EntityFrameworkCore;
using Movies.TwilightSaw.Models;

namespace Movies.TwilightSaw.Data;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Series> Series { get; set; }

    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>();
        modelBuilder.Entity<Series>();
    }
}