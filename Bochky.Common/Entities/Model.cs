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

        public Model (int id, string name, Category category)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;
            this.ID = id;
            this.Category = category;
        }

        public Model (string name, Category category)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;           
            this.Category = category;
        }
    }
}
