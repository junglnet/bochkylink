using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BochkyLink.Common.Entities;
using BochkyLink.Common.Interfaces;

namespace BochkyLink.Common.Interfaces
{
    /// <summary>
    /// UI добавления новой спецификации
    /// </summary>
    public interface IAddNewSpecUI
    {
        ISettings Settings { get; }
        IAddNewSpecService NewSpecService { get; }


    }
}
