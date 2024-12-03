using OrdinarioAPIPOO.Data;
using OrdinarioAPIPOO.Models;
using Microsoft.EntityFrameworkCore;

namespace OrdinarioAPIPOO.Data
{
    public class PosterContext : DbContext
    {
        public PosterContext(DbContextOptions<PosterContext> options) : base(options) { }

        public DbSet<Poster> Posters { get; set; }
    }
}
