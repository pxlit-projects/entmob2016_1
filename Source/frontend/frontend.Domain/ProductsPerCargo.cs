﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Domain
{
    public class ProductsPerCargo
    {
        public ProductsPerCargoPK Id { get; set; }
        public Product Product { get; set; }
        public Cargo Cargo { get; set; }
        public int Amount { get; set; }
    }
}
