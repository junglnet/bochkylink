using BochkyLink.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает модель
    /// </summary>
    public class Model : DictionaryBase, ISortable, IComparable
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int SortIndex { get; set; }
        public Model (int id, string name, Category category, int sotrIndex)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;
            this.ID = id;
            this.Category = category;
            SortIndex = sotrIndex;
        }

        public Model (string name, Category category)
        {
            if (name == "" || name == null) throw new System.Exception("Имя модели не может быть пустым");
            this.Name = name;           
            this.Category = category;
        }

        public int CompareTo(object o)
        {
            Model p = o as Model;
            if (p != null)
                return this.SortIndex.CompareTo(p.SortIndex);
            else
                throw new System.Exception("Невозможно сравнить два объекта");
        }
    }
}
