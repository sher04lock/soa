﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public Person Author { get; set; }
        public int MovieId { get; set; }
    }
}
