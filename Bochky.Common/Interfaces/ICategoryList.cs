using System;
using System.Collections.Generic;
using System.Text;
using BochkyLink.Common.Entities;

namespace BochkyLink.Common.Interfaces
{
    public interface ICategoryList
    {
        /// <summary>
        /// Перечень доступных категорий
        /// </summary>               
        Category[] Categories { get; set; }
    }
}
