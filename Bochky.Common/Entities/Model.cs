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
        public Category Category { get; set; }

        public int SortIndex { get; set; }

        public Model (int id, string name, Category category, int sortIndex = 0)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;
            this.ID = id;
            this.Category = category;
            SortIndex = sortIndex;
        }

        public Model (string name, Category category, int sortIndex = 0)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;           
            this.Category = category;
            SortIndex = sortIndex;
        }
    }
}
