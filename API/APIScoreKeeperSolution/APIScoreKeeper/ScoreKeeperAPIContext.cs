namespace APIScoreKeeper
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ScoreKeeperAPIContext : DbContext
    {
        public ScoreKeeperAPIContext()
            : base("name=ScoreKeeperAPIContext")
        {
        }

        public virtual DbSet<score> scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
