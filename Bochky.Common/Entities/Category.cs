using System;
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

        public int SortIndex { get; set; }

        public Category(int id, string name, int sortIndex = 0)
        {
            if (name == "" || name == null) throw new System.Exception("Имя категории не может быть пустым");           
            this.ID = id;
            this.Name = name;
            SortIndex = sortIndex;
        }
        public Category(string name, int sortIndex = 0)
        {
            if (name == "" || name == null) throw new System.Exception("Имя категории не может быть пустым");
            this.Name = name;
            SortIndex = sortIndex;
        }
    }
}
