using Domain.Entitties;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }

    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Track> Tracks { get; set; }
}