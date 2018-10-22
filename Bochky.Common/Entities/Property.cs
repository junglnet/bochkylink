﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochkyLink.Common.Entities
{
    [Serializable]
    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Property(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }


    }
}
