using System;
using System.ComponentModel.DataAnnotations;

namespace APIScoreKeeper.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Games { get; set; }
        public DateTime LastGame { get; set; }
    }
}