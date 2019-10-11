using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DenunciasASP.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Localidad> Localidads { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Contextura> Contexturas { get; set; }
        public DbSet<DelitoTipo> DelitoTipos { get; set; }       
        public DbSet<Estado> Estados { get; set; }
        public DbSet<LugarAfectado> LugarAfectados { get; set; }
        public DbSet<ObjetoAfectado> ObjetoAfectados { get; set; }
        public DbSet<ObjetoUtilizado> ObjetoUtilizados { get; set; }
        public DbSet<PresuntoAutor> PresuntoAutors { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<Testigos> Testigos { get; set; }
        public DbSet<Victima> Victimas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }
}