
namespace TiendaTecno.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.IO.Compression;
    using TiendaTecno.Web.Models;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

