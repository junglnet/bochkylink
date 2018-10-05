using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Entities
{
    public class CategoriesList 
    {
        private List<Category> Categories { get; set; }

        public CategoriesList()
        {
            Categories = new List<Category>();
        }

        public int Length
        {
            get { return Categories.Count;}
        }

        public Category this[int index]
        {
            get
            {
                return Categories[index];
            }
            set
            {
                Categories[index] = value;
            }
        }
        // ? Почему не смог реализовать через интерфейс IEnumerable
        public IEnumerator<Category> GetEnumerator()
        {
            return Categories.GetEnumerator();
        }

        public void Add(Category newCategory)
        {
            Categories.Add(newCategory);
        }

        public List<string> ToNameList()
        {
            List<string> list = new List<string>();

            if (Categories.Count > 0)
                return Categories.Select(c => c.Name).ToList();
            else return null;
        }
    }
}
