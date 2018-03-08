using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace VanzTube.Models
{
    public class VanzTubeContext : IdentityDbContext
    {
        public VanzTubeContext(): base("VanzTubeConnection") {

            //Database.SetInitializer(new CreateDatabaseIfNotExists<VanzTubeContext>());
            Database.SetInitializer<VanzTubeContext>(null);
        }
        
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoCategory> VideoCategories { get; set; }
    }
}