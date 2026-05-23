using Lab8_Contactos_C20051.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab8_Contactos_C20051.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contacto> Contactos { get; set; }
    }
}