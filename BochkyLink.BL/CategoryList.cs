using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;
using BochkyLink.Source;

namespace BochkyLink.BL
{
    /// <summary>
    /// Слой бизнес-логики формирования категории
    /// </summary>
    public class CategoryList : ICategoryList
    {
        public Category[] Categories { get; set; }


        public CategoryList(Settings settings)
        {   

        }
        public void GetCategoriesList(DataBase db)
        {

        }
    }
}
