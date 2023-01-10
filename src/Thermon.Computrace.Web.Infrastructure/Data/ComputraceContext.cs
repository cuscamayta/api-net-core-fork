using Microsoft.EntityFrameworkCore;
using Thermon.Computrace.Web.Core.Entities;

namespace Thermon.Computrace.Web.Infrastructure.Data
{
    // Context class for command
    public class ComputraceContext : DbContext
    {
        public ComputraceContext(DbContextOptions<ComputraceContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Circuits> Circuits { get; set; }
        public DbSet<Segments> Segments { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<ConnectionInfo> ConnectionInfo { get; set; }
    }
}
