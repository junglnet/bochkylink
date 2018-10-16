using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Entities
{
    public class CommonCategoryValidator : ICategoryValidator
    {
        public bool IsValid(string category)
        {
            if(category == "") return false;

            return true;
        }
    }
}
