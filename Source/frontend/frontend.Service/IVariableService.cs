﻿using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IVariableService
    {
        List<Variable> All();
        Variable Find(int id);
        void Add(Variable variable);
        void Update(Variable variable);
        void Delete(int id);
    }
}