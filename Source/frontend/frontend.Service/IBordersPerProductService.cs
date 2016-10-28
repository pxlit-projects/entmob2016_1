﻿using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IBordersPerProductService
    {
        List<BorderPerProduct> All();
        BorderPerProduct Find(int id);
        void Add(BorderPerProduct bordersPerProduct);
        void Update(BorderPerProduct bordersPerProduct);
        void Delete(int id);
    }
}
