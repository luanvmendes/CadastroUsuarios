using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Model;

namespace UsersService.Infra.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
