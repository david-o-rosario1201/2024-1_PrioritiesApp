using Microsoft.EntityFrameworkCore;
using PrioritiesApp.Models;

namespace PrioritiesApp.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Priorities> Priorities { get; set; }
	public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Sistemas> Sistemas { get; set;}
    public DbSet<Tickets> Tickets { get; set; }
}