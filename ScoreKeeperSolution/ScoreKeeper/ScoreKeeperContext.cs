namespace ScoreKeeper
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
