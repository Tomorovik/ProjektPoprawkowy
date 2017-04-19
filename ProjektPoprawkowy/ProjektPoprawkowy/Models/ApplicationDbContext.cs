using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjektPoprawkowy.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AudioFile> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}