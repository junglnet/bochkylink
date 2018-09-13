using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    public class ModelList
    {
        /// <summary>
        /// Модели
        /// </summary>               
        public IEnumerable<Model> Models { get; set; }

        /// <summary>
        /// Категория моделей
        /// </summary> 
        public string Category { get; set; }
    }
}
