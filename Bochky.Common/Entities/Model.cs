using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает модель
    /// </summary>
    public class Model : DictionaryBase
    {
        public string Name { get; set; }
        public Category CategoryName { get; set; }
    }
}
