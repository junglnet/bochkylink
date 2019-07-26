using BochkyLink.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BochkyLink.Common.Entities
{
    /// <summary>
    /// Класс описывает категорию
    /// </summary>
    public class Category : DictionaryBase, ISortable, IComparable
    {
        public string Name { get; set; }
        public int SortIndex { get; set; }

        public Category(int id, string name, int sotrIndex)
        {
            if (name == "" || name == null)
                throw new System.Exception("Имя категории не может быть пустым");

            this.ID = id;

            this.Name = name;

            SortIndex = sotrIndex;
        }
        public Category(string name, int sotrIndex)
        {
            if (name == "" || name == null)
                throw new System.Exception("Имя категории не может быть пустым");

            this.Name = name;

            SortIndex = sotrIndex;
        }

        public Category(string name)
        {
            if (name == "" || name == null)
                throw new System.Exception("Имя категории не может быть пустым");

            this.Name = name;

            
        }




        public int CompareTo(object o)
        {
            Category p = o as Category;
            if (p != null)
                return this.SortIndex.CompareTo(p.SortIndex);
            else
                throw new System.Exception("Невозможно сравнить два объекта");
        }

    }
}
