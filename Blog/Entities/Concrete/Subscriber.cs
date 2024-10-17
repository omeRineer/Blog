﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Subscriber : BaseEntity<long>, IEntity
    {
        public string Email { get; set; }
    }
}