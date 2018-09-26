﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает категорию
    /// </summary>
    public class Category : DictionaryBase
    {
        public string Name { get; set; }

        public Category(string name)
        {
            this.Name = name;
        }
    }
}
