using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// Взамодействие с DataBase через используемые сущности 
    /// </summary>
    public interface IDataBaseAdapter
    {
        IDataBase DataBase { get;  }
        
        /// <summary>
        /// Получение объкта "Список категорий"
        /// </summary>
        CategoriesList GetCategoriesList();

        /// <summary>
        /// Получение объкта "Список моделей категории"
        /// </summary>
        List<Model> GetModelListByCategory(Category currentCanegory);

        SpecificationFile GetSpecificationFile(Model currentModel);        
    }
}
