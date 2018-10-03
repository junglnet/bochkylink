using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    public interface ISpecService
    {
        /// <summary>
        /// Перечень доступных категорий
        /// </summary> 
        List<string> CategoriesNameList { get; set; }
        List<Category> CategoriesList { get; set; }
        
        /// <summary>
        /// Модели
        /// </summary>                       
        List<string> ModelsNameList { get; set; }
        List<Model> ModelsList { get; set; }
        
        /// <summary>
        /// Категория моделей
        /// </summary> 
        string Category { get; set; }
        Category CurrentCategory { get; set; }
        
        /// <summary>
        /// Относительный путь до спецификации
        /// </summary>  
        string Path { get;}
        
        /// <summary>
        /// Текущая модель
        /// </summary> 
        string Model { get;}
        Model CurrentModel { get; set; }
    }
}
