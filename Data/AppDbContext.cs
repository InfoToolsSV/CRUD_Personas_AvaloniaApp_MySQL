using Microsoft.EntityFrameworkCore;
using PersonaApp.Models;

namespace PersonaApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;database=personadb;user=root;password=123John@";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}