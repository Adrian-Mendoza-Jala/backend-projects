﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public interface IProductNameStep
    {
        IProductDescriptionStep SetName(string name);
    }
}
