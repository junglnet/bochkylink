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
        public List<Category> Categories { get; set; }

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

        public void addCategory(Category newCategory)
        {
            Categories.Add(newCategory);
        }

        private void GetListFromDB(IDataBase db)
        {

        }
    }
}
