﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
