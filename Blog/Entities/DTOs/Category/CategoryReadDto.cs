﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Category
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleCount { get; set; }
        public string Image { get; set; }
    }
}
