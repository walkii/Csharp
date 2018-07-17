﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIScoreKeeper.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Games { get; set; }
    }
}