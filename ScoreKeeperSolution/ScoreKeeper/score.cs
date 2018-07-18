namespace ScoreKeeper
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("score")]
    public partial class score
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        public int POINTS { get; set; }

        public int GAMES { get; set; }

        public DateTime LASTGAME { get; set; }
    }
}
