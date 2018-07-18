namespace ScoreKeeper
{
    using System.Data.Entity;

    public partial class ScoreKeeperContext : DbContext
    {
        public ScoreKeeperContext()
            : base("name=ScoreKeeperContext")
        {
        }

        public virtual DbSet<score> scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
